using System;
using System.Collections.Generic;
using System.Drawing;

namespace CreateDungeon
{
    /// <summary>
    /// ブロック種類列挙
    /// </summary>
    public enum BLOCK_TYPE
    {
        /// <summary>
        /// 壁
        /// </summary>
        WALL,
        /// <summary>
        /// 部屋
        /// </summary>
        ROOM,
        /// <summary>
        /// 道
        /// </summary>
        ROAD
    }

    /// <summary>
    /// ダンジョン生成時の返却ステータス列挙
    /// </summary>
    public enum CREATE_DUNGEON_STATUS
    {
        /// <summary>
        /// 生成OK
        /// </summary>
        OK,
        /// <summary>
        /// 生成OK、大部屋生成
        /// </summary>
        OK_BIG_ROOM,
        /// <summary>
        /// 生成NG、部屋配置失敗
        /// </summary>
        NG_PUT_ROOM,
        /// <summary>
        /// 生成NG、道の出入口配置失敗
        /// </summary>
        NG_PUT_ROAD_EXIT,
        /// <summary>
        /// 生成NG、道配置失敗
        /// </summary>
        NG_PUT_ROAD,
        /// <summary>
        /// 生成NG、道を置ける空間がない
        /// </summary>
        NG_PUT_ROAD_NOT_SPACE
    }

    /// <summary>
    /// ダンジョン生成機
    /// </summary>
    class DungeonGenerator
    {
        /// <summary>
        /// ランダム配置の試行上限
        /// </summary>
        private const int LIMIT_RANDOM_RUN = 10000;

        /// <summary>
        /// 部屋間の最低距離
        /// </summary>
        private const int ROOM_MIN_DISTANCE = 3;

        // 上下左右のコード値
        // 0：上 1：下 2：右 3：左
        /// <summary>
        /// 方向コード値．上
        /// </summary>
        private const int DIR_UP = 0;
        /// <summary>
        /// 方向コード値．下
        /// </summary>
        private const int DIR_DOWN = 1;
        /// <summary>
        /// 方向コード値．右
        /// </summary>
        private const int DIR_RIGHT = 2;
        /// <summary>
        /// 方向コード値．左
        /// </summary>
        private const int DIR_LEFT = 3;

        /// <summary>
        /// ダンジョンの縦幅
        /// </summary>
        public int DungeonSizeHeight { get; private set; }

        /// <summary>
        /// ダンジョンの横幅
        /// </summary>
        public int DungeonSizeWidth { get; private set; }

        /// <summary>
        /// ダンジョンマップ
        /// </summary>
        public BLOCK_TYPE[,] DungeonMap { get; private set; }

        /// <summary>
        /// ダンジョン生成情報の初期化
        /// 部屋サイズを変更する際はこちらを使用する
        /// </summary>
        public void Init(int dungeonSizeWidth, int dungeonSizeHeight)
        {
            DungeonSizeWidth = dungeonSizeWidth;
            DungeonSizeHeight = dungeonSizeHeight;
            DungeonMap = new BLOCK_TYPE[DungeonSizeWidth, DungeonSizeHeight];
        }

        /// <summary>
        /// 指定した1ブロック辺りの長さから、ダンジョン描画サイズを返却する
        /// </summary>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        public Size GetDungeonSize(int blockSize)
        {
            return new Size(DungeonSizeWidth * blockSize, DungeonSizeHeight * blockSize);
        }

        /// <summary>
        /// マップを指定のブロックで埋める
        /// </summary>
        /// <param name="fillBlock"></param>
        public void FillBlock(BLOCK_TYPE fillBlock)
        {
            for (int y = 0; y < DungeonSizeHeight; y++)
            {
                for (int x = 0; x < DungeonSizeWidth; x++)
                {
                    // すべてのブロックに壁をセット
                    DungeonMap[x, y] = fillBlock;
                }
            }
        }

        /// <summary>
        /// マップを全て壁で埋める
        /// </summary>
        public void FillWall()
        {
            FillBlock(BLOCK_TYPE.WALL);
        }

        /// <summary>
        /// 大部屋を生成する
        /// </summary>
        public void CreateBigRoom()
        {
            // すべて部屋にする
            FillBlock(BLOCK_TYPE.ROOM);

            // 外周を壁で埋める
            // 上下
            for (int x = 0; x < DungeonSizeWidth; x++)
            {
                DungeonMap[x, 0] = BLOCK_TYPE.WALL;
                DungeonMap[x, DungeonSizeHeight - 1] = BLOCK_TYPE.WALL;
            }
            // 左右
            for (int y = 0; y < DungeonSizeHeight; y++)
            {
                DungeonMap[0, y] = BLOCK_TYPE.WALL;
                DungeonMap[DungeonSizeWidth - 1, y] = BLOCK_TYPE.WALL;
            }
        }

        /// <summary>
        /// ダンジョン生成
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public CREATE_DUNGEON_STATUS CreateDungeonMap(DungionProperty property)
        {
            // 乱数インスタンス生成
            Random random = new Random();

            // 大部屋ダイスを振る
            int probabilityBigRoom = random.Next(0, 100);
            if (property.BigRoomProbability > probabilityBigRoom)
            {
                // 大部屋生成して処理を抜ける
                CreateBigRoom();
                return CREATE_DUNGEON_STATUS.OK_BIG_ROOM;
            }

            // 部屋数を取得する
            int roomCount = random.Next(property.RoomCountMin, property.RoomCountMax + 1);
            // 部屋設定管理リスト生成
            List<RoomProperty> putRooms = new List<RoomProperty>();

            // 部屋を配置する
            for (int i = 0; i < roomCount; i++)
            {
                // 部屋サイズを生成する
                int roomSizeX = random.Next(property.RoomSizeMin, property.RoomSizeMax + 1);
                int roomSizeY = random.Next(property.RoomSizeMin, property.RoomSizeMax + 1);

                // 部屋を配置する
                // 条件を満たすまで配置を試みる
                bool isPutRoom = false;
                int loopCount = 0;
                while (!isPutRoom)
                {
                    if (loopCount > LIMIT_RANDOM_RUN)
                    {
                        // 試行上限数を越えた場合、生成失敗とし、壁で埋める
                        Console.WriteLine("部屋配置に失敗しました。");
                        FillWall();
                        return CREATE_DUNGEON_STATUS.NG_PUT_ROOM;
                    }

                    // 配置座標を生成する
                    // 1～部屋サイズ-1まで
                    int roomLocationX = random.Next(1, DungeonSizeWidth - roomSizeX);
                    int roomLocationY = random.Next(1, DungeonSizeHeight - roomSizeY);

                    RoomProperty roomProperty = new RoomProperty(roomSizeX, roomSizeY, roomLocationX, roomLocationY);

                    // 生成座標に部屋を配置できるか判定する
                    isPutRoom = GetIsPutRoom(roomProperty, putRooms);
                    if (isPutRoom)
                    {
                        // 配置できたら追加する
                        putRooms.Add(roomProperty);
                    }

                    loopCount++;
                }
            }

            // 最初に壁で埋める
            FillWall();

            // 配置した部屋のブロック種類を部屋にする
            foreach (RoomProperty putRoom in putRooms)
            {
                int roomLocationXRight = putRoom.GetRoomLocationXRight();
                int roomLocationnYBottom = putRoom.GetRoomLocationYBottom();

                for (int x = putRoom.RoomLocationX; x < roomLocationXRight; x++)
                {
                    for (int y = putRoom.RoomLocationY; y < roomLocationnYBottom; y++)
                    {
                        DungeonMap[x, y] = BLOCK_TYPE.ROOM;
                    }
                }
            }

            // 道を決定する
            // 一番目の部屋から順番に引くことですべての部屋にいけるように繋ぐ
            RoomProperty firstRoom = putRooms[0];
            for (int i = 1; i < putRooms.Count; i++)
            {
                // 道の出元の部屋を取得
                RoomProperty roadRoom = putRooms[random.Next(0, i)];
                // 伸びている道を追加
                roadRoom.RoadRoomNoList.Add(i);
            }

            // 道を引く
            foreach (RoomProperty putRoom in putRooms)
            {
                // 伸びている分だけその方向へ道を引く
                foreach (int roadRoomNo in putRoom.RoadRoomNoList)
                {
                    // 道を引く先の部屋を取得
                    RoomProperty roadTargetRoom = putRooms[roadRoomNo];
                    // 始発座標と到着座標を生成(部屋に隣接する4隅以外)
                    if (!GetRoomExitLocation(putRoom, random, out int startX, out int startY) ||
                        !GetRoomExitLocation(roadTargetRoom, random, out int goalX, out int goalY))
                    {
                        // 道が配置できなかった場合、生成失敗とする
                        Console.WriteLine("道の開始位置と終了位置配置に失敗しました。");
                        return CREATE_DUNGEON_STATUS.NG_PUT_ROAD_EXIT;
                    }

                    // 配置箇所順位付け配列生成
                    int[] putDirRanking = new int[4];
                    // 道配置座標
                    int putX = startX;
                    int putY = startY;
                    // 前回動いた方向
                    int beforePutDir = -1;
                    // ループカウント
                    int loopCount = 0;
                    // 道が弾き終わるまでループする
                    while (true)
                    {
                        if (loopCount > LIMIT_RANDOM_RUN)
                        {
                            // 試行上限数を越えた場合、生成失敗とし、壁で埋める
                            Console.WriteLine("道配置に失敗しました。");
                            // ※失敗位置が分かりやすいように、道の開始終了位置は部屋ブロックにする
                            DungeonMap[startX, startY] = BLOCK_TYPE.ROOM;
                            DungeonMap[goalX, goalY] = BLOCK_TYPE.ROOM;
                            return CREATE_DUNGEON_STATUS.NG_PUT_ROAD;
                        }

                        // 道を配置する
                        DungeonMap[putX, putY] = BLOCK_TYPE.ROAD;

                        // 道を進める
                        // 現在位置とゴール地点の位置関係より、進めたい方向を順位付けする
                        int differenceX = goalX - putX;
                        int differenceY = goalY - putY;

                        // 既にゴールが道と隣接している場合、ループを終了する
                        if ((differenceX == 0 && Math.Abs(differenceY) == 1) ||
                            (differenceY == 0 && Math.Abs(differenceX) == 1))
                        {
                            break;
                        }

                        // 横と縦の方向のどちらに行く力が強いかを決定する(縦：-1 横：1 同じ：0)
                        int directionPower = GetCompareNum(Math.Abs(differenceX) - Math.Abs(differenceY), 0);
                        if (directionPower == 0)
                        {
                            // 同じ場合はランダム
                            directionPower = random.Next(2) == 0 ? -1 : 1;
                        }

                        // 順位付け変数
                        int yRankTop, yRankUnder, xRankTop, xRankUnder;

                        if (directionPower == -1)
                        {
                            // 縦に強い
                            yRankTop = 0;
                            xRankTop = 1;
                            xRankUnder = 2;
                            yRankUnder = 3;
                        }
                        else
                        {
                            // 横に強い
                            xRankTop = 0;
                            yRankTop = 1;
                            yRankUnder = 2;
                            xRankUnder = 3;
                        }

                        if (differenceY < 0)
                        {
                            // 上方向に強い
                            putDirRanking[yRankTop] = DIR_UP;
                            putDirRanking[yRankUnder] = DIR_DOWN;

                        }
                        else if (differenceY > 0)
                        {
                            // 下方向に強い
                            putDirRanking[yRankTop] = DIR_DOWN;
                            putDirRanking[yRankUnder] = DIR_UP;

                        }
                        else
                        {
                            // ゴールY座標が同じ場合、広い側へ向かう
                            if (DungeonSizeHeight - putY >= DungeonSizeHeight / 2)
                            {
                                putDirRanking[yRankTop] = DIR_DOWN;
                                putDirRanking[yRankUnder] = DIR_UP;
                            }
                            else
                            {
                                putDirRanking[yRankTop] = DIR_UP;
                                putDirRanking[yRankUnder] = DIR_DOWN;
                            }
                        }

                        if (differenceX < 0)
                        {
                            // 右方向に強い
                            putDirRanking[xRankTop] = DIR_LEFT;
                            putDirRanking[xRankUnder] = DIR_RIGHT;
                        }
                        else if (differenceX > 0)
                        {
                            // 左方向に強い
                            putDirRanking[xRankTop] = DIR_RIGHT;
                            putDirRanking[xRankUnder] = DIR_LEFT;
                        }
                        else
                        {
                            // ゴールX座標が同じ場合、広い側へ向かう
                            if (DungeonSizeWidth - putX >= DungeonSizeWidth / 2)
                            {
                                putDirRanking[xRankTop] = DIR_LEFT;
                                putDirRanking[xRankUnder] = DIR_RIGHT;
                            }
                            else
                            {
                                putDirRanking[xRankTop] = DIR_RIGHT;
                                putDirRanking[xRankUnder] = DIR_LEFT;
                            }
                        }

                        // 部屋の上下4辺のうち、置けるマスを割り出す
                        // 置けるマスの条件：進み先の3辺が画面外か部屋に隣接せず、前回の移動元じゃないこと
                        bool isPutUp = beforePutDir != DIR_DOWN && putY - 2 > 0 && DungeonMap[putX, putY - 2] != BLOCK_TYPE.ROOM
                            && DungeonMap[putX + 1, putY - 2] != BLOCK_TYPE.ROOM && DungeonMap[putX - 1, putY - 2] != BLOCK_TYPE.ROOM;
                        bool isPutDown = beforePutDir != DIR_UP && putY + 2 < DungeonSizeHeight - 1 && DungeonMap[putX, putY + 2] != BLOCK_TYPE.ROOM
                        && DungeonMap[putX + 1, putY + 2] != BLOCK_TYPE.ROOM && DungeonMap[putX - 1, putY + 2] != BLOCK_TYPE.ROOM;
                        bool isPutRight = beforePutDir != DIR_LEFT && putX + 2 < DungeonSizeWidth - 1 && DungeonMap[putX + 2, putY] != BLOCK_TYPE.ROOM
                        && DungeonMap[putX + 2, putY + 1] != BLOCK_TYPE.ROOM && DungeonMap[putX + 2, putY - 1] != BLOCK_TYPE.ROOM;
                        bool isPutLeft = beforePutDir != DIR_RIGHT && putX - 2 > 0 && DungeonMap[putX - 2, putY] != BLOCK_TYPE.ROOM
                        && DungeonMap[putX - 2, putY + 1] != BLOCK_TYPE.ROOM && DungeonMap[putX - 2, putY - 1] != BLOCK_TYPE.ROOM;

                        if (!isPutUp && !isPutDown && !isPutRight && !isPutLeft)
                        {
                            // どこにも道が置けなかった場合、生成失敗とする
                            Console.WriteLine("道配置に失敗しました。配置できる空間が見当たりません。");
                            // ※失敗位置が分かりやすいように、道の開始終了位置は部屋ブロックにする
                            DungeonMap[startX, startY] = BLOCK_TYPE.ROOM;
                            DungeonMap[goalX, goalY] = BLOCK_TYPE.ROOM;
                            return CREATE_DUNGEON_STATUS.NG_PUT_ROAD_NOT_SPACE;
                        }

                        // 進みたい方向ランク順に道移動を試行する
                        foreach (int putDir in putDirRanking)
                        {
                            bool isPut = false;
                            switch (putDir)
                            {
                                case DIR_UP:
                                    isPut = isPutUp;
                                    if (isPut)
                                    {
                                        putY--;
                                        beforePutDir = DIR_UP;
                                    }
                                    break;
                                case DIR_DOWN:
                                    isPut = isPutDown;
                                    if (isPut)
                                    {
                                        putY++;
                                        beforePutDir = DIR_DOWN;
                                    }
                                    break;
                                case DIR_RIGHT:
                                    isPut = isPutRight;
                                    if (isPut)
                                    {
                                        putX++;
                                        beforePutDir = DIR_RIGHT;
                                    }
                                    break;
                                case DIR_LEFT:
                                    isPut = isPutLeft;
                                    if (isPut)
                                    {
                                        putX--;
                                        beforePutDir = DIR_LEFT;
                                    }
                                    break;
                                default:
                                    // 上記以外の値が取得できた場合はエラーとする
                                    throw new Exception("道の生成方向決め処理でエラー。方向番号：" + putDir.ToString());
                            }
                            if (isPut)
                            {
                                break;
                            }
                        }

                        loopCount++;

                    }

                    // ゴール地点に道を引く
                    DungeonMap[goalX, goalY] = BLOCK_TYPE.ROAD;
                }
            }

            // 成功したら生成OKを返却
            return CREATE_DUNGEON_STATUS.OK;
        }

        /// <summary>
        /// 数値の大小関係を返却する
        /// targetA < targetB：-1
        /// targetA = targetB：0
        /// targetA > targetB：1
        /// </summary>
        /// <param name="targetA"></param>
        /// <param name="targetB"></param>
        /// <returns></returns>
        private int GetCompareNum(int targetA, int targetB)
        {
            if (targetA < targetB)
            {
                return -1;
            }
            else if (targetA == targetB)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        ///  生成した部屋を配置できるか判定する
        /// </summary>
        /// <param name="roomProperty"></param>
        /// <param name="putRooms"></param>
        /// <returns></returns>
        private bool GetIsPutRoom(RoomProperty roomProperty, List<RoomProperty> putRooms)
        {
            // 既存の部屋と重なっているかを判定する
            foreach (RoomProperty putRoom in putRooms)
            {
                // X軸の判定
                if (putRoom.GetRoomLocationXRight() + ROOM_MIN_DISTANCE - 1 < roomProperty.RoomLocationX ||
                    roomProperty.GetRoomLocationXRight() + ROOM_MIN_DISTANCE - 1 < putRoom.RoomLocationX)
                {
                    continue;
                }
                // Y軸の判定

                if (putRoom.GetRoomLocationYBottom() + ROOM_MIN_DISTANCE - 1 < roomProperty.RoomLocationY ||
                    roomProperty.GetRoomLocationYBottom() + ROOM_MIN_DISTANCE - 1 < putRoom.RoomLocationY)
                {
                    continue;
                }

                // X、Yで範囲内の場合、falseを返却する
                return false;
            }

            // すべての判定を終えた場合はtrueを返却する
            return true;
        }

        /// <summary>
        /// 部屋の出口座標を取得する
        /// </summary>
        /// <param name="roomProperty"></param>
        /// <param name="random"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool GetRoomExitLocation(RoomProperty roomProperty, Random random, out int x, out int y)
        {
            // 部屋の四辺のうち、道を配置できる辺を取得する(道配置できるのは、壁が3つある空間のみ)
            List<int> isPutSideList = new List<int>();
            if (roomProperty.RoomLocationY - 3 >= 0)
            {
                isPutSideList.Add(DIR_UP);
            }
            if (roomProperty.GetRoomLocationYBottom() + 3 < DungeonSizeHeight)
            {
                isPutSideList.Add(DIR_DOWN);
            }
            if (roomProperty.GetRoomLocationXRight() + 3 < DungeonSizeWidth)
            {
                isPutSideList.Add(DIR_RIGHT);
            }
            if (roomProperty.RoomLocationX - 3 >= 0)
            {
                isPutSideList.Add(DIR_LEFT);
            }

            if (isPutSideList.Count == 0)
            {
                // どこにも道を配置できない場合、falseを返却
                x = -1;
                y = -1;
                return false;
            }

            int startSide = isPutSideList[random.Next(isPutSideList.Count)];

            // 部屋座標生成(四隅は避ける)
            switch (startSide)
            {
                case DIR_UP:
                    // 上：Xはランダム、Yは部屋の上座標の一つ上
                    x = random.Next(roomProperty.RoomLocationX + 1, roomProperty.GetRoomLocationXRight());
                    y = roomProperty.RoomLocationY - 1;
                    break;
                case DIR_DOWN:
                    // 下：Xはランダム、Yは部屋の下座標の一つ下
                    x = random.Next(roomProperty.RoomLocationX + 1, roomProperty.GetRoomLocationXRight());
                    y = roomProperty.GetRoomLocationYBottom();
                    break;
                case DIR_RIGHT:
                    // 右：Yはランダム、Xは部屋の右座標の一つ右
                    x = roomProperty.GetRoomLocationXRight();
                    y = random.Next(roomProperty.RoomLocationY + 1, roomProperty.GetRoomLocationYBottom());
                    break;
                case DIR_LEFT:
                    // 左：Yはランダム、Xは部屋の左座標の一つ左
                    x = roomProperty.RoomLocationX - 1;
                    y = random.Next(roomProperty.RoomLocationY + 1, roomProperty.GetRoomLocationYBottom());
                    break;
                default:
                    // 上記以外の値が取得できた場合はエラーとする
                    throw new Exception("道の開始座標取得処理でエラー。辺の番号：" + startSide.ToString());
            }

            // 道配置成功でtrue返却
            return true;
        }

        /// <summary>
        /// ダンジョン設定情報プロパティクラス
        /// </summary>
        public class DungionProperty
        {
            /// <summary>
            /// 部屋最大数
            /// </summary>
            public int RoomCountMax { get; set; }

            /// <summary>
            /// 部屋最小数(最大数と同じで固定数となる)
            /// </summary>
            public int RoomCountMin { get; set; }

            /// <summary>
            /// 部屋の最大サイズ
            /// </summary>
            public int RoomSizeMax { get; set; }

            /// <summary>
            /// 部屋の最小サイズ(最大サイズと同じで固定数となる)
            /// </summary>
            public int RoomSizeMin { get; set; }

            /// <summary>
            /// 大部屋生成確率(0～100を設定、不正値は0扱い)
            /// </summary>
            public int BigRoomProbability { get; set; } = 0;
        }


        /// <summary>
        /// 部屋情報プロパティクラス
        /// </summary>
        private class RoomProperty
        {
            /// <summary>
            /// 部屋の横幅
            /// </summary>
            public int RoomSizeX { get; set; }

            /// <summary>
            /// 部屋の縦幅
            /// </summary>
            public int RoomSizeY { get; set; }

            /// <summary>
            /// 部屋のX座標(左上)
            /// </summary>
            public int RoomLocationX { get; set; }

            /// <summary>
            /// 部屋のY座標(左上)
            /// </summary>
            public int RoomLocationY { get; set; }

            /// <summary>
            /// 部屋から伸びている道番号
            /// </summary>
            public List<int> RoadRoomNoList { get; set; } = new List<int>();

            /// <summary>
            /// 部屋座標の右端を取得する
            /// </summary>
            /// <returns></returns>
            public int GetRoomLocationXRight()
            {
                return RoomLocationX + RoomSizeX;
            }

            /// <summary>
            /// 部屋座標の下端を取得する
            /// </summary>
            /// <returns></returns>
            public int GetRoomLocationYBottom()
            {
                return RoomLocationY + RoomSizeY;
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="roomSizeX"></param>
            /// <param name="roomSizeY"></param>
            /// <param name="roomLocationX"></param>
            /// <param name="roomLocationY"></param>
            public RoomProperty(int roomSizeX, int roomSizeY, int roomLocationX, int roomLocationY)
            {
                RoomSizeX = roomSizeX;
                RoomSizeY = roomSizeY;
                RoomLocationX = roomLocationX;
                RoomLocationY = roomLocationY;
            }
        }
    }
}
