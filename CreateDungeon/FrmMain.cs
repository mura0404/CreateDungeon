using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CreateDungeon
{
    public partial class FrmMain : Form
    {
        // 描画初期値情報
        /// <summary>
        /// 初期値．部屋数最大値
        /// </summary>
        private const int INIT_ROOM_COUNT_MAX = 5;

        /// <summary>
        /// 初期値．部屋数最小値
        /// </summary>
        private const int INIT_ROOM_COUNT_MIN = 2;

        /// <summary>
        /// 初期値．部屋幅最大値
        /// </summary>
        private const int INIT_ROOM_SIZE_MAX = 40;

        /// <summary>
        /// 初期値．部屋幅最小値
        /// </summary>
        private const int INIT_ROOM_SIZE_MIN = 20;

        /// <summary>
        /// 初期値．大部屋生成確率
        /// </summary>
        private const int INIT_BIG_ROOM_PROBABILITY = 0;

        /// <summary>
        /// 初期値．ブロック描画時のサイズ(px)
        /// </summary>
        private const int INIT_BLOCK_SIZE = 5;

        /// <summary>
        /// 初期値．ダンジョンの縦幅(ブロック数)
        /// </summary>
        private const int INIT_DUNGEON_SIZE_HEIGHT = 90;

        /// <summary>
        /// 初期値．ダンジョンの横幅(ブロック数)
        /// </summary>
        private const int INIT_DUNGEON_SIZE_WIDTH = 120;

        /// <summary>
        /// ブロック種類と描画色ペア
        /// </summary>
        private readonly Dictionary<BLOCK_TYPE, Brush> BLOCK_COLOR_PAIR = new Dictionary<BLOCK_TYPE, Brush>()
        {
            {BLOCK_TYPE.WALL, Brushes.Chocolate},
            {BLOCK_TYPE.ROOM, Brushes.LightGray},
            {BLOCK_TYPE.ROAD, Brushes.LightBlue}
        };

        /// <summary>
        /// ダンジョン生成機
        /// </summary>
        private DungeonGenerator dungeonGenerator = new DungeonGenerator();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 入力項目に初期値を設定
            nudRoomCountMin.Value = INIT_ROOM_COUNT_MIN;
            nudRoomCountMax.Value = INIT_ROOM_COUNT_MAX;
            nudRoomSizeMin.Value = INIT_ROOM_SIZE_MIN;
            nudRoomSizeMax.Value = INIT_ROOM_SIZE_MAX;
            nudBigRoomProbability.Value = INIT_BIG_ROOM_PROBABILITY;

            nudDungeonSizeWidth.Value = INIT_DUNGEON_SIZE_WIDTH;
            nudDungeonSizeHeight.Value = INIT_DUNGEON_SIZE_HEIGHT;
            nudBlockSize.Value = INIT_BLOCK_SIZE;

            // ダンジョン初期化
            InitDungeon();
        }


        /// <summary>
        /// 生成ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // 入力チェック(範囲指定は大小関係を確認する)
                if (nudRoomCountMin.Value > nudRoomCountMax.Value)
                {
                    lblInfoMessage.Text = "部屋生成数範囲指定不正";
                    return;
                }
                if (nudRoomSizeMin.Value > nudRoomSizeMax.Value)
                {
                    lblInfoMessage.Text = "部屋幅範囲指定不正";
                    return;
                }

                // ダンジョンプロパティ生成
                DungeonGenerator.DungionProperty dungionProperty = new DungeonGenerator.DungionProperty()
                {
                    RoomCountMax = (int)nudRoomCountMax.Value,
                    RoomCountMin = (int)nudRoomCountMin.Value,
                    RoomSizeMax = (int)nudRoomSizeMax.Value,
                    RoomSizeMin = (int)nudRoomSizeMin.Value,
                    BigRoomProbability = (int)nudBigRoomProbability.Value
                };

                CREATE_DUNGEON_STATUS status = dungeonGenerator.CreateDungeonMap(dungionProperty);

                string message = "";
                switch (status)
                {
                    case CREATE_DUNGEON_STATUS.OK:
                        message = "ダンジョン生成しました。";
                        break;
                    case CREATE_DUNGEON_STATUS.OK_BIG_ROOM:
                        message = "ダンジョン生成しました。大部屋生成。";
                        break;
                    case CREATE_DUNGEON_STATUS.NG_PUT_ROOM:
                        message = "ダンジョン生成に失敗しました。部屋配置失敗。";
                        break;
                    case CREATE_DUNGEON_STATUS.NG_PUT_ROAD_EXIT:
                        message = "ダンジョン生成に失敗しました。道の出入口配置失敗。";
                        break;
                    case CREATE_DUNGEON_STATUS.NG_PUT_ROAD:
                        message = "ダンジョン生成に失敗しました。道配置失敗。";
                        break;
                    case CREATE_DUNGEON_STATUS.NG_PUT_ROAD_NOT_SPACE:
                        message = "ダンジョン生成に失敗しました。道を置ける空間がない。";
                        break;
                }

                lblInfoMessage.Text = message;

                // 描画
                pbDungeon.Image = PaintMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "予期せぬエラーが発生しました。", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 設定ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeProperty_Click(object sender, EventArgs e)
        {
            InitDungeon();
        }

        /// <summary>
        /// ダンジョン初期化処理
        /// </summary>
        private void InitDungeon()
        {
            // ダンジョン生成器を初期化
            dungeonGenerator.Init((int)nudDungeonSizeWidth.Value, (int)nudDungeonSizeHeight.Value);
            // ダンジョン表示領域サイズ設定
            pbDungeon.Size = dungeonGenerator.GetDungeonSize((int)nudBlockSize.Value);
            // デフォルトブロック配置
            PutDefaultBlock();

            // GUIのラベル表示を変更
            lblDungeonSizeWidth.Text = nudDungeonSizeWidth.Value.ToString();
            lblDungeonSizeHeight.Text = nudDungeonSizeHeight.Value.ToString();
            lblBlockSize.Text = nudBlockSize.Value.ToString();
            lblPbDungeonWidth.Text = pbDungeon.Size.Width.ToString();
            lblPbDungeonHeight.Text = pbDungeon.Size.Height.ToString();

            lblInfoMessage.Text = "ダンジョン生成情報を初期化しました。";

        }

        /// <summary>
        /// デフォルトブロック配置
        /// </summary>
        private void PutDefaultBlock()
        {
            // 壁配置
            dungeonGenerator.FillWall();

            // 描画
            pbDungeon.Image = PaintMap();
        }

        /// <summary>
        /// マップ描画
        /// </summary>
        /// <returns>マップイメージ</returns>
        private Bitmap PaintMap()
        {
            // ビットマップ生成
            Bitmap bitMap = new Bitmap(pbDungeon.Size.Width, pbDungeon.Size.Height);

            using (Graphics g = Graphics.FromImage(bitMap))
            {
                for (int y = 0; y < dungeonGenerator.DungeonSizeHeight; y++)
                {
                    for (int x = 0; x < dungeonGenerator.DungeonSizeWidth; x++)
                    {
                        // 座標よりペンを取得
                        Brush b = BLOCK_COLOR_PAIR[dungeonGenerator.DungeonMap[x, y]];
                        // 描画
                        int blockSize = (int)nudBlockSize.Value;
                        g.FillRectangle(b, x * blockSize, y * blockSize, blockSize, blockSize);
                    }
                }
            }
            return bitMap;
        }
    }
}
