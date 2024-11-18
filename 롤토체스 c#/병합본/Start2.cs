using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using static System.Windows.Forms.DataFormats;
using game00;
using static game00.Program;


namespace game00
{
    public partial class Start2 : Form
    {
        public static Start2 instance; // Singleton 인스턴스
        public static List<Image> championImages1;
        // Champion 클래스 정의
        public class Champion
        {
            public string Name { get; set; } // 챔피언 이름
            public int Price { get; set; } // 챔피언 가격
            public int Health { get; set; } // 챔피언 체력
            public int Attack { get; set; } // 챔피언 공격력
            public int Defense { get; set; } // 챔피언 방어력
            public string Synergy { get; set; } // 챔피언 시너지
            public Image Image_3D { get; set; }   // 챔피언 3D 이미지

            public Champion(string name, int price, int health, int attack, int defense, string synergy, Image image_3D)
            {
                Name = name;
                Price = price;
                Health = health;
                Attack = attack;
                Defense = defense;
                Synergy = synergy;
                Image_3D = image_3D;
            }
        }

        private Start1 form1; // Form1의 인스턴스
        private int[] imageIndices; // 랜덤 챔피언 인덱스를 저장하는 배열
        private int[] index; // 챔피언 인덱스 배열
        private Random random = new Random(); // 랜덤 숫자 생성기
        private Button selectedChampionButton; // 현재 선택된 챔피언 버튼
        private Button selectedFieldButton; // 선택된 필드 버튼을 저장할 변수

        // 챔피언 목록
        private List<Champion> champions = new List<Champion>
        {
            new Champion("Gragas", 1, 200, 30, 15, "Light",Properties.Resources.Gragas_3D),
            new Champion("Kha'Zix", 1, 200, 40, 5, "Light",Properties.Resources.Kha_Zix_3D),
            new Champion("Vladimir",1,200,30,15,"Dark",Properties.Resources.Vladimir_3D),
            new Champion("Soraka", 2, 250, 35, 20, "Light",Properties.Resources.Soraka_3D),
            new Champion("Sejuani",2,250,35,20,"Dark",Properties.Resources.Sejuani_3D),
            new Champion("Nidalee", 3, 300, 55, 10, "Light",Properties.Resources.Nidalee_3D),
            new Champion("Riven", 3, 300, 45, 20, "Light",Properties.Resources.Riven_3D),
            new Champion("Leesin",3,300,55,10,"Dark",Properties.Resources.Leesin_3D),
            new Champion("Yasuo",3,300,55,10,"Dark",Properties.Resources.Yasuo_3D),
            new Champion("Karma", 4, 350, 65, 10, "Light",Properties.Resources.Karma_3D),
            new Champion("Aphelios",4,350,65,10,"Dark",Properties.Resources.Aphelios_3D),
            new Champion("Diana",4,350,65,10,"Dark",Properties.Resources.Diana_3D),
            new Champion("Garen", 5, 400, 60, 25, "Light",Properties.Resources.Garen_3D)
        };

        private Timer countdownTimer; // 카운트다운 타이머
        private int remainingTime = 15; // 30초 카운트다운
        public void initmoney()
        {
            lb_money.Text = 10.ToString();
        }
        public bool iisInitialized = false;
        private Start2(Start1 form1, List<Image> championImages)
        {
            InitializeComponent(); // 폼 초기화
            this.StartPosition = FormStartPosition.CenterScreen;
            this.form1 = form1; // Form1 인스턴스 할당
            randomchampion(); // 폼 로드 시 랜덤 챔피언 초기화
            InitializeTimer(); // 타이머 초기화

            if (!iisInitialized)
            {
                initmoney();
                iisInitialized = true;
            }
        }
        // Singleton 인스턴스를 가져오는 메서드
        public static Start2 GetInstance(Start1 form1, List<Image> championImages)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Start2(form1, championImages);
                championImages1 = championImages;
                instance.InitializeTimer(); // 타이머 초기화
                instance.ResetTimer(); // 타이머 시작
            }
            else
            {
                championImages1 = championImages;
                instance.ResetTimer(); // 기존 인스턴스가 있을 경우 타이머 초기화
                instance.randomchampion(); // 리롤
            }
            return instance;
        }
        // 카운트다운 타이머 초기화
        public void InitializeTimer()
        {
            if (countdownTimer == null) // 타이머가 null일 때만 생성
            {
                countdownTimer = new Timer(); // 타이머 생성
                countdownTimer.Interval = 1000; // 1초 간격
                countdownTimer.Tick += CountdownTimer_Tick; // 타이머 틱 이벤트 핸들러 연결
            }
        }
        public void ResetTimer()
        {
            remainingTime = 15; // 원하는 초기 시간으로 설정
            progressBar1.Value = remainingTime; // 진행 바 초기화
            countdownTimer.Start(); // 타이머 시작
        }

        // 타이머 틱 이벤트 핸들러
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--; // 1초 감소
            progressBar1.Value = remainingTime; // 프로그래스 바 업데이트

            if (remainingTime <= 0)
            {
                countdownTimer.Stop(); // 타이머 중지
                MessageBox.Show("시간이 다 되었습니다! 진행 상황을 저장합니다...");
                //레벨포인트 증가
                lb_levelpoint.Text = (int.Parse(lb_levelpoint.Text) + 2).ToString();
                levelupup();
                //폼1의 이자
                if (int.Parse(lb_money.Text) >= 50)
                {
                    lb_money.Text = (int.Parse(lb_money.Text) + 10).ToString();
                }
                else if (int.Parse(lb_money.Text) >= 40)
                {
                    lb_money.Text = (int.Parse(lb_money.Text) + 8).ToString();
                }
                else if (int.Parse(lb_money.Text) >= 30)
                {
                    lb_money.Text = (int.Parse(lb_money.Text) + 6).ToString();
                }
                else if (int.Parse(lb_money.Text) >= 20)
                {
                    lb_money.Text = (int.Parse(lb_money.Text) + 4).ToString();
                }
                else if (int.Parse(lb_money.Text) >= 10)
                {
                    lb_money.Text = (int.Parse(lb_money.Text) + 2).ToString();
                }
                lb_money.Text = Convert.ToString(int.Parse(lb_money.Text) + 5);
                OpenForm3(); // Form3 열기
            }
        }
        public List<Image> championImages2 = new List<Image>();

        private List<Champion> team2 = new List<Champion>();

        //시너지 적용
        private void ApplySynergyEffects(List<Champion> team)
        {
            // 챔피언 중복 여부 확인
            var uniqueChampions = team.GroupBy(c => c.Name)
                                       .Select(g => g.First())
                                       .ToList();

            var lightChampions = uniqueChampions.Where(c => c.Synergy == "Light").ToList();
            var darkChampions = uniqueChampions.Where(c => c.Synergy == "Dark").ToList();

            // 기본 이미지 제거
            pb_synergy.BackgroundImage = null;
            pb_synergy1.BackgroundImage = null;
            if (pb_synergy.BackgroundImage == null)
            {
                // Light 시너지 처리
                if (lightChampions.Count >= 6)
                {
                    pb_synergy.BackgroundImage = Properties.Resources._6빛의_인도자;
                }
                else if (lightChampions.Count >= 4)
                {
                    pb_synergy.BackgroundImage = Properties.Resources._4빛의인도자;
                }
                else if (lightChampions.Count >= 2)
                {
                    pb_synergy.BackgroundImage = Properties.Resources._2빛의_인도자;
                }
            }
            if (pb_synergy.BackgroundImage == null)
            {
                // Dark 시너지 처리
                if (darkChampions.Count >= 6)
                {
                    pb_synergy.BackgroundImage = Properties.Resources._6어둠의_인도자;
                }
                else if (darkChampions.Count >= 4)
                {
                    pb_synergy.BackgroundImage = Properties.Resources._4어둠의_인도자;
                }
                else if (darkChampions.Count >= 2)
                {
                    pb_synergy.BackgroundImage = Properties.Resources._2어둠의_인도자;
                }

                // Light와 Dark 시너지가 모두 2 미만이면 이미지 제거
                if (lightChampions.Count < 2 && darkChampions.Count < 2)
                {
                    pb_synergy.BackgroundImage = null;
                }
            }
            if (pb_synergy.BackgroundImage != null && pb_synergy1.BackgroundImage == null && lightChampions.Count >= 2)
            {
                // Dark 시너지 처리
                if (darkChampions.Count >= 6)
                {
                    pb_synergy1.BackgroundImage = Properties.Resources._6어둠의_인도자;
                }
                else if (darkChampions.Count >= 4)
                {
                    pb_synergy1.BackgroundImage = Properties.Resources._4어둠의_인도자;
                }
                else if (darkChampions.Count >= 2)
                {
                    pb_synergy1.BackgroundImage = Properties.Resources._2어둠의_인도자;
                }

                // Light와 Dark 시너지가 모두 2 미만이면 이미지 제거
                if (lightChampions.Count < 2 && darkChampions.Count < 2)
                {
                    pb_synergy1.BackgroundImage = null;
                }
            }

        }

        private bool CompareImages(Image img1, Image img2)
        {
            if (img1 == null || img2 == null)
                return false;

            // 이미지가 동일한지 픽셀 단위로 비교
            if (img1.Size != img2.Size)
                return false;

            using (var bmp1 = new Bitmap(img1))
            using (var bmp2 = new Bitmap(img2))
            {
                for (int y = 0; y < bmp1.Height; y++)
                {
                    for (int x = 0; x < bmp1.Width; x++)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                            return false;
                    }
                }
            }
            return true;
        }

        private void OpenForm3()
        {
            // 필드 버튼에서 이미지 수집
            for (int i = 1; i <= 21; i++)
            {
                Button fieldButton = this.Controls.Find($"btn_field{i}", true).FirstOrDefault() as Button;
                if (fieldButton != null)
                {
                    championImages2.Add(fieldButton.BackgroundImage); // 이미지가 null일 경우도 포함
                }
            }

            // 21개의 이미지를 맞춰서 null로 패딩
            while (championImages2.Count < 21)
            {
                championImages2.Add(null); // null 추가하여 21개 맞춤
            }
            Start3 form3 = new Start3(form1, this, championImages1, championImages2);// Form3 인스턴스 생성
            form3.Show();  // Form3 표시
            this.Hide();  // 현재 폼 숨기기
        }

        // 랜덤 챔피언 설정 메서드
        private void randomchampion()
        {
            Button[] selectButtons = { btn_select1, btn_select2, btn_select3, btn_select4, btn_select5 };

            foreach (var button in selectButtons)
            {
                button.Enabled = true; // 버튼을 활성화
            }

            imageIndices = new int[5];           // 이미지 인덱스 배열 초기화
            index = new int[5];                  // 챔피언 인덱스 배열 초기화

            // 랜덤 챔피언 선택
            for (int i = 0; i < imageIndices.Length; i++)
            {
                int championIndex;
                if (int.Parse(lb_level.Text) == 3)
                {
                    championIndex = random.Next(0, 5); // 랜덤 인덱스 생성
                }
                else if (int.Parse(lb_level.Text) == 4)
                {
                    championIndex = random.Next(0, 9);
                }
                else if (int.Parse(lb_level.Text) == 5)
                {
                    championIndex = random.Next(0, 12);
                }
                else
                    championIndex = random.Next(0, champions.Count);
                imageIndices[i] = championIndex;                     // 인덱스 저장
                AssignImageToButton(i, champions[championIndex]);    // 버튼에 이미지 할당
                index[i] = championIndex;                            // 인덱스 저장
            }
        }

        // 버튼에 챔피언 이미지를 할당하는 메서드
        private void AssignImageToButton(int index, Champion champion)
        {
            Image image = GetChampionImage(champion.Name); // 챔피언 이미지 가져오기
            if (image != null)
            {
                image.Tag = champion; // 이미지를 태그에 챔피언 객체 설정
            }

            // 버튼에 이미지 할당
            switch (index)
            {
                case 0: btn_select1.Image = image; break;
                case 1: btn_select2.Image = image; break;
                case 2: btn_select3.Image = image; break;
                case 3: btn_select4.Image = image; break;
                case 4: btn_select5.Image = image; break;
            }
        }

        // 챔피언 이미지 가져오기 메서드
        private Image GetChampionImage(string name)
        {
            return name switch
            {
                "Gragas" => Properties.Resources.그라가스_1코,
                "Kha'Zix" => Properties.Resources.카직스_1코,
                "Soraka" => Properties.Resources.소라카_2코,
                "Nidalee" => Properties.Resources.니달리_3코,
                "Riven" => Properties.Resources.리븐_3코,
                "Karma" => Properties.Resources.카르마_4코,
                "Garen" => Properties.Resources.가렌_5코,
                "Vladimir" => Properties.Resources.Vladimir,
                "Sejuani" => Properties.Resources.Sejuani,
                "Leesin" => Properties.Resources.Leesin,
                "Yasuo" => Properties.Resources.Yasuo,
                "Diana" => Properties.Resources.Diana,
                "Aphelios" => Properties.Resources.Aphelios,
                _ => null,
            };
        }

        // 챔피언 대기석 배치 메서드
        private void PlaceChampion(Button selectButton)
        {
            // 선택된 챔피언의 이름을 가져옵니다.
            Champion selectedChampion = selectButton.Image.Tag as Champion;

            // 선택된 챔피언이 null이 아닐 경우
            if (selectedChampion != null)
            {
                Image championImage3D = selectedChampion.Image_3D; // 3D 이미지 가져오기

                // 빈 챔피언 대기석 버튼에 챔피언 배치
                for (int i = 1; i <= 9; i++)
                {
                    Button championButton = this.Controls.Find($"btn_champion{i}", true).FirstOrDefault() as Button;
                    if (championButton != null && championButton.BackgroundImage == null) // 배경 이미지가 비어있으면
                    {
                        championButton.BackgroundImage = championImage3D; // 필드에 3D 챔피언 이미지 설정
                        selectButton.Image = Properties.Resources.사고난뒤; // 선택 버튼 비우기
                        selectButton.Enabled = false; // 버튼 비활성화
                        break;
                    }
                }
            }
        }

        // 돈 차감 메서드
        private bool DeductMoney(int championIndex)
        {
            if (IsChampionFull()) // 챔피언이 가득 찼는지 확인
            {
                MessageBox.Show("챔피언이 가득찼습니다!"); // 알림
                return false;
            }

            Champion champion = champions[championIndex]; // 챔피언 객체 가져오기
            int price = champion.Price; // 챔피언 가격
            int currentMoney = int.Parse(lb_money.Text); // 현재 돈

            // 돈이 부족한지 확인
            if (currentMoney < price)
            {
                MessageBox.Show("챔피언을 살 수 없습니다. 돈이 부족합니다."); // 알림
                return false;
            }

            lb_money.Text = Convert.ToString(currentMoney - price); // 돈 차감
            return true;
        }

        // 챔피언 가득 찼는지 확인하는 메서드
        private bool IsChampionFull()
        {
            return (btn_champion1.BackgroundImage != null) && (btn_champion2.BackgroundImage != null) &&
                   (btn_champion3.BackgroundImage != null) && (btn_champion4.BackgroundImage != null) &&
                   (btn_champion5.BackgroundImage != null) && (btn_champion6.BackgroundImage != null) &&
                   (btn_champion7.BackgroundImage != null) && (btn_champion8.BackgroundImage != null) &&
                   (btn_champion9.BackgroundImage != null);
        }

        // 챔피언 가격 가져오는 메서드
        private int GetChampionPrice(Image championImage)
        {
            // 챔피언 이미지가 null이면 0 반환
            if (championImage == null)
                return 0;

            // 모든 챔피언을 검사하여 해당 이미지를 찾고 가격 반환
            foreach (var champion in champions)
            {
                if (champion.Image_3D == championImage) // 3D 이미지를 비교
                {
                    return champion.Price; // 가격 반환
                }
            }
            return 0; // 찾지 못한 경우 0 반환
        }

        // 버튼 클릭 이벤트 처리
        private void btn_select1_Click_1(object sender, EventArgs e) { if (DeductMoney(index[0])) PlaceChampion(btn_select1); }
        private void btn_select2_Click_1(object sender, EventArgs e) { if (DeductMoney(index[1])) PlaceChampion(btn_select2); }
        private void btn_select3_Click_1(object sender, EventArgs e) { if (DeductMoney(index[2])) PlaceChampion(btn_select3); }
        private void btn_select4_Click_1(object sender, EventArgs e) { if (DeductMoney(index[3])) PlaceChampion(btn_select4); }
        private void btn_select5_Click_1(object sender, EventArgs e) { if (DeductMoney(index[4])) PlaceChampion(btn_select5); }

        // 판매할 챔피언 선택
        private void ChampionButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            // 선택된 버튼이 있을 경우
            if (selectedFieldButton != null)
            {
                if (clickedButton != null && clickedButton.BackgroundImage == null)
                {
                    clickedButton.BackgroundImage = selectedFieldButton.BackgroundImage; // 필드에 챔피언 이미지 설정
                    selectedFieldButton.BackgroundImage = null; // 필드 버튼 비우기
                    selectedFieldButton = null; // 선택 해제
                }
            }
            else
            {
                if (clickedButton != null && clickedButton.BackgroundImage != null)
                {
                    selectedChampionButton = clickedButton; // 선택된 챔피언 버튼 저장
                    selectedFieldButton = null; // 필드 버튼 선택 해제
                }
            }
            UpdateTeamFromField();
            ApplySynergyEffects(team2);
        }

        // 필드에 현재 배치된 챔피언 수를 계산하는 헬퍼 메서드
        private int CountChampionsInField()
        {
            int count = 0;
            for (int i = 1; i <= 21; i++)
            {
                Button fieldButton = this.Controls.Find($"btn_field{i}", true).FirstOrDefault() as Button;
                if (fieldButton != null && fieldButton.BackgroundImage != null)
                {
                    count++;
                }
            }
            return count;
        }

        private void UpdateTeamFromField()
        {
            team2.Clear(); // 기존 리스트 비우기

            // 필드의 챔피언을 리스트에 추가
            for (int i = 1; i <= 21; i++)
            {
                Button fieldButton = this.Controls.Find($"btn_field{i}", true).FirstOrDefault() as Button;
                if (fieldButton != null && fieldButton.BackgroundImage != null)
                {
                    Champion champion = GetChampionByImage(fieldButton.BackgroundImage); // 이미지에 해당하는 챔피언 가져오기
                    if (champion != null)
                    {
                        team2.Add(champion); // 리스트에 추가
                    }
                }
            }
        }

        private Champion GetChampionByImage(Image image)
        {
            // 이미지에 해당하는 챔피언을 찾는 로직
            return champions.FirstOrDefault(c => c.Image_3D == image);
        }

        // 필드에 챔피언 배치 함수
        private void FieldButton_Click(object sender, EventArgs e)
        {
            Button fieldButton = sender as Button;

            // 필드 버튼에 챔피언이 있을 경우
            if (fieldButton.BackgroundImage != null)
            {
                selectedFieldButton = fieldButton; // 선택된 필드 버튼 저장
            }
            else if (selectedFieldButton != null) // 선택된 필드 버튼이 있을 경우
            {
                // 이미지 교환
                fieldButton.BackgroundImage = selectedFieldButton.BackgroundImage; // 현재 클릭된 필드 버튼에 이미지 설정
                selectedFieldButton.BackgroundImage = null; // 선택된 필드 버튼 비우기
                selectedFieldButton = null; // 선택 해제
            }
            else if (selectedChampionButton != null && selectedChampionButton.BackgroundImage != null)
            {
                // 현재 필드에 배치된 챔피언 수를 계산
                int currentChampionsCount = CountChampionsInField();
                int maxChampions = int.Parse(lb_level.Text); // 레벨에 따른 최대 챔피언 수

                if (currentChampionsCount < maxChampions) // 현재 수가 최대 수보다 작으면
                {
                    fieldButton.BackgroundImage = selectedChampionButton.BackgroundImage; // 필드 버튼에 챔피언 설정
                    selectedChampionButton.BackgroundImage = null; // 선택된 챔피언 버튼 비우기
                    selectedChampionButton = null; // 선택 해제
                }
                else
                {
                    MessageBox.Show($"필드에 더 이상 챔피언을 배치할 수 없습니다! 최대 {maxChampions}명까지 배치할 수 있습니다.");
                }
            }
            UpdateTeamFromField();
            ApplySynergyEffects(team2);
        }

        // 판매 버튼 클릭
        private void btn_sell_Click(object sender, EventArgs e)
        {
            // 선택된 필드 버튼이 있을 경우
            if (selectedFieldButton != null && selectedFieldButton.BackgroundImage != null)
            {
                int price = GetChampionPrice(selectedFieldButton.BackgroundImage); // 가격 계산
                MessageBox.Show($"판매할 챔피언의 가격: {price}"); // 알림

                selectedFieldButton.BackgroundImage = null; // 필드 버튼 비우기

                int currentMoney = int.Parse(lb_money.Text); // 현재 돈
                lb_money.Text = Convert.ToString(currentMoney + price); // 돈 증가
                UpdateTeamFromField();
                ApplySynergyEffects(team2);

                selectedFieldButton = null; // 선택 해제
            }
            // 선택된 챔피언 버튼이 있을 경우
            else if (selectedChampionButton != null && selectedChampionButton.BackgroundImage != null)
            {
                int price = GetChampionPrice(selectedChampionButton.BackgroundImage); // 가격 계산
                MessageBox.Show($"판매할 챔피언의 가격: {price}"); // 알림

                selectedChampionButton.BackgroundImage = null; // 챔피언 버튼 비우기

                int currentMoney = int.Parse(lb_money.Text); // 현재 돈
                lb_money.Text = Convert.ToString(currentMoney + price); // 돈 증가

                selectedChampionButton = null; // 선택 해제
            }
            else
            {
                MessageBox.Show("판매할 챔피언이 선택되지 않았습니다."); // 알림
            }
        }

        // 리롤 버튼 클릭
        private void btn_reroll_Click(object sender, EventArgs e)
        {
            if (int.Parse(lb_money.Text) < 2) // 돈이 부족한지 확인
            {
                MessageBox.Show("돈이 부족합니다."); // 알림
                return;
            }

            lb_money.Text = Convert.ToString(int.Parse(lb_money.Text) - 2); // 돈 차감
            btn_select1.Enabled = true; // 버튼 활성화
            btn_select2.Enabled = true;
            btn_select3.Enabled = true;
            btn_select4.Enabled = true;
            btn_select5.Enabled = true;

            randomchampion(); // 랜덤 챔피언 설정
        }

        // 레벨업 버튼 클릭
        private void btn_levelup_Click(object sender, EventArgs e)
        {
            if (int.Parse(lb_money.Text) < 2) // 돈이 부족한지 확인
            {
                MessageBox.Show("돈이 부족합니다."); // 알림
                return;
            }

            lb_money.Text = Convert.ToString(int.Parse(lb_money.Text) - 2); // 돈 차감
            int currentLevel = int.Parse(lb_level.Text); // 현재 레벨
            int currentLevelPoint = int.Parse(lb_levelpoint.Text); // 현재 레벨 포인트
            int nextLevelPoint = GetNextLevelPoint(currentLevel); // 다음 레벨 포인트 요구량

            if (currentLevelPoint < nextLevelPoint) // 레벨 포인트 증가
            {
                lb_levelpoint.Text = Convert.ToString(currentLevelPoint + 2);
            }
            else // 레벨업
            {
                lb_levelpoint.Text = "0"; // 포인트 초기화
                lb_level.Text = Convert.ToString(currentLevel + 1); // 레벨 증가
                UpdateLevelPointRequirement(currentLevel + 1); // 레벨 요구량 업데이트
            }
        }

        //레벨업!!!
        private void levelupup()
        {
            int currentLevel = int.Parse(lb_level.Text); // 현재 레벨
            int currentLevelPoint = int.Parse(lb_levelpoint.Text); // 현재 레벨 포인트
            int nextLevelPoint = GetNextLevelPoint(currentLevel); // 다음 레벨 포인트 요구량

            if (currentLevelPoint > nextLevelPoint) // 레벨 포인트 증가
            {
                lb_levelpoint.Text = "0"; // 포인트 초기화
                lb_level.Text = Convert.ToString(currentLevel + 1); // 레벨 증가
                UpdateLevelPointRequirement(currentLevel + 1); // 레벨 요구량 업데이트
            }
        }

        // 다음 레벨 포인트를 가져오는 메서드
        private int GetNextLevelPoint(int level)
        {
            return level switch
            {
                3 => 8, // 3레벨 요구량
                4 => 18, // 4레벨 요구량
                5 => 28, // 5레벨 요구량
                _ => int.MaxValue // 그 외는 무한
            };
        }

        // 레벨 포인트 요구량 업데이트
        private void UpdateLevelPointRequirement(int level)
        {
            switch (level)
            {
                case 4:
                    lb_1.Text = "/20"; // 4레벨 요구량
                    break;
                case 5:
                    lb_1.Text = "/30"; // 5레벨 요구량
                    break;
                case 6:
                    btn_levelup.Enabled = false; // 6레벨 이상은 비활성화
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (SharedData.image2 == 1)
            {
                button1.BackgroundImage = Properties.Resources.돌돌이원본1;
            }
            else if (SharedData.image2 == 2)
            {
                button1.BackgroundImage = Properties.Resources.얼음원본1;
            }
            else if (SharedData.image2 == 3)
            {
                button1.BackgroundImage = Properties.Resources.모래원본1;
            }
            else if (SharedData.image2 == 4)
            {
                button1.BackgroundImage = Properties.Resources.감시자원본1;
            }

            if (SharedData.image == 1)
            {
                BackgroundImage = Properties.Resources.ll20;
            }
            else if (SharedData.image == 2)
            {
                BackgroundImage = Properties.Resources.oo35_1;
            }
            else if (SharedData.image == 3)
            {
                BackgroundImage = Properties.Resources.oo35_2;
            }
            else if (SharedData.image == 4)
            {
                BackgroundImage = Properties.Resources.oo35_3;
            }

            // 챔피언 버튼 클릭 이벤트 핸들러 추가
            for (int i = 1; i <= 9; i++)
            {
                Button championButton = this.Controls.Find($"btn_champion{i}", true).FirstOrDefault() as Button;
                if (championButton != null)
                {
                    championButton.Click += ChampionButton_Click; // 챔피언 버튼 클릭 이벤트 핸들러 추가
                }
            }

            // 필드 버튼 클릭 이벤트 핸들러 추가
            for (int i = 1; i <= 21; i++)
            {
                Button fieldButton = this.Controls.Find($"btn_field{i}", true).FirstOrDefault() as Button;
                if (fieldButton != null)
                {
                    fieldButton.Click += FieldButton_Click; // 필드 버튼 클릭 이벤트 핸들러 추가
                }
            }
        }
        public void UpdateTeam2Images(List<Image> images)
        {
            for (int i = 0; i < 21; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    // 이미지를 직접 할당
                    button.BackgroundImage = (i < images.Count) ? images[i] : null;
                }
            }
            UpdateTeamFromField();
            ApplySynergyEffects(team2);
        }

        private void btn_levelup_MouseEnter(object sender, EventArgs e)
        {
            btn_levelup.BackgroundImage = Properties.Resources.levelupgray;
        }

        private void btn_levelup_MouseLeave(object sender, EventArgs e)
        {
            btn_levelup.BackgroundImage = Properties.Resources.levelup;
        }

        private void btn_reroll_MouseEnter(object sender, EventArgs e)
        {
            btn_reroll.BackgroundImage = Properties.Resources.rerollgray;
        }

        private void btn_reroll_MouseLeave(object sender, EventArgs e)
        {
            btn_reroll.BackgroundImage = Properties.Resources.reroll;
        }

        private void btn_sureender_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("정말로 항복하시겠습니까?", "항복 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                countdownTimer.Stop();           // 타이머 중지
                int a = 2;
                // 동영상 폼 열기
                var videoForm = new Start4(a);
                videoForm.Show(); // 동영상 폼 표시
                this.Hide(); // 현재 폼 숨기기
                return;
            }
        }
    }
}
