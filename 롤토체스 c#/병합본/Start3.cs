using game00;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static game00.Program;


namespace game00
{
    public partial class Start3 : Form
    {
        private List<Image> championImages1;
        private List<Image> championImages2;
        private Start2 form2;
        private Start1 form1;

        public class Champion
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Health { get; set; }
            public int Attack { get; set; }
            public int Defense { get; set; }
            public string Synergy { get; set; }
            public Image Image_3D { get; set; }

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

        private List<Champion> champions;
        private List<Champion> team1 = new List<Champion>();
        private List<Champion> team2 = new List<Champion>();

        public Start3(Start1 form1, Start2 form2, List<Image> championImages1, List<Image> championImages2)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.form1 = form1; // 폼1 참조 저장
            this.form2 = form2; // 폼2 참조 저장
            // championImages1 리스트가 21개 이상일 경우 앞에서부터 21개 삭제
            if (championImages1.Count > 21)
            {
                championImages1.RemoveRange(0, 21);
            }
            if (championImages2.Count > 21)
            {
                championImages2.RemoveRange(0, 21);
            }
            this.championImages1 = championImages1;
            this.championImages2 = championImages2;

            champions = new List<Champion>
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

            List<Image> allChampionImages = championImages1.Concat(championImages2).ToList();
            AssignButtonImages(allChampionImages);
            InitializeTeams(); // 팀 초기화
            lb_life1.Text = form1.lb_life.Text;
            lb_life2.Text = form2.lb_life.Text;

        }

        private void AssignButtonImages(List<Image> allChampionImages)
        {
            for (int i = 0; i < allChampionImages.Count; i++)
            {
                var fieldButton = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (fieldButton != null && i < allChampionImages.Count)
                {
                    fieldButton.BackgroundImage = allChampionImages[i];
                }
            }
        }

        private void InitializeTeams()
        {
            // 팀 1: 첫 번째 버튼부터 21개
            for (int i = 0; i < 21; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null && button.BackgroundImage != null)
                {
                    var champion = champions.FirstOrDefault(c => CompareImages(c.Image_3D, button.BackgroundImage));
                    if (champion != null)
                    {
                        // 팀 1에 챔피언 추가 시 순서에 따라 번호 부여
                        string uniqueName = $"{champion.Name} {team1.Count + 1}";
                        team1.Add(new Champion(uniqueName, champion.Price, champion.Health, champion.Attack, champion.Defense, champion.Synergy, champion.Image_3D));
                    }
                }
            }

            // 팀 2: 22번째 버튼부터 42개
            for (int i = 21; i < 42; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null && button.BackgroundImage != null)
                {
                    var champion = champions.FirstOrDefault(c => CompareImages(c.Image_3D, button.BackgroundImage));
                    if (champion != null)
                    {
                        // 팀 2에 챔피언 추가 시 순서에 따라 번호 부여
                        string uniqueName = $"{champion.Name} {team2.Count + 6}";
                        team2.Add(new Champion(uniqueName, champion.Price, champion.Health, champion.Attack, champion.Defense, champion.Synergy, champion.Image_3D));
                    }
                }
            }

            // 팀 구성 결과 출력
            AppendToLog("팀 1 구성 완료:");
            foreach (var champion in team1)
            {
                AppendToLog(champion.Name);
            }
            // 공격 전 시너지 효과 적용
            ApplySynergyEffects(team1);
            AppendToLog("팀 2 구성 완료:");
            foreach (var champion in team2)
            {
                AppendToLog(champion.Name);
            }
            // 공격 전 시너지 효과 적용
            ApplySynergyEffects(team2);

            // 결과 확인
            if (team1.Count == 0)
                AppendToLog("팀 1에 챔피언이 없습니다.");
            if (team2.Count == 0)
                AppendToLog("팀 2에 챔피언이 없습니다.");
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

        private void AppendToLog(string message)
        {
            textBox1.AppendText(message + Environment.NewLine);
            textBox1.ScrollToCaret();

            // 마지막 100줄로 제한
            var lines = textBox1.Lines;
            if (lines.Length > 100)
            {
                textBox1.Lines = lines.Skip(lines.Length - 100).ToArray();
            }
        }


        private async void StartBattle()
        {
            int round = 1;
            AppendToLog("전투 시작!");

            while (team1.Any(c => c.Health > 0) && team2.Any(c => c.Health > 0))
            {
                textBox1.Clear();
                AppendToLog($"--- {round} 라운드 ---");

                // 팀 1의 공격
                await ExecuteAttack(team1, team2);

                // 팀 2의 공격
                await ExecuteAttack(team2, team1);

                // 각 팀의 상태 출력
                LogTeamStatus(team1, "팀 1");
                LogTeamStatus(team2, "팀 2");

                round++;
                AppendToLog("");
                await Task.Delay(2000); // 3초 지연

                // 라운드 종료 시 체력이 0인 챔피언의 이미지 삭제 및 팀에서 제거
                RemoveDefeatedChampions(team1);
                RemoveDefeatedChampions(team2);
            }
            textBox1.Clear();
            // 전투 종료 후 승자 확인
            if (!team1.Any(c => c.Health > 0) && !team2.Any(c => c.Health > 0))
            {
                AppendToLog("무승부입니다!");
                form1.lb_life.Text = (int.Parse(form1.lb_life.Text) - 2).ToString();
                form2.lb_life.Text = (int.Parse(form2.lb_life.Text) - 2).ToString();

                // 생명 감소 체크
                if (int.Parse(form1.lb_life.Text) <= 0 || int.Parse(form2.lb_life.Text) <= 0)
                {
                    await Task.Delay(5000); // 5초 지연
                    // 동영상 폼 열기
                    var videoForm = new Start4(form1, form2, this);
                    videoForm.Show(); // 동영상 폼 표시
                    this.Hide(); // 현재 폼 숨기기
                    return;
                }
                UpdateChampionImages(); // 이미지 업데이트 호출

                // 폼1의 인스턴스를 가져와서 초기화합니다.
                if (form1 != null)
                {
                    await Task.Delay(5000); // 5초 지연
                    form1.InitializeTimer(); // 타이머 초기화 메서드 호출
                    form1.ResetTimer(); // remainingTime 초기화 메서드 호출
                    form1.randomchampion();
                    form1.Show(); // 폼1 표시
                }
                this.Hide(); // 현재 폼 숨기기
                return;
            }
            else
            {
                var winner = team1.Any(c => c.Health > 0) ? "팀 1" : "팀 2";
                AppendToLog($"{winner}이 승리했습니다!");
            }

            Damage();
            // 생명 감소 체크
            if (int.Parse(form1.lb_life.Text) <= 0 || int.Parse(form2.lb_life.Text) <= 0)
            {
                await Task.Delay(5000); // 5초 지연
                // 동영상 폼 열기
                var videoForm = new Start4(form1, form2, this);
                videoForm.Show(); // 동영상 폼 표시
                this.Hide(); // 현재 폼 숨기기
                return;
            }
            // 이미지 업데이트
            UpdateChampionImages(); // 이미지 업데이트 호출

            // 폼1의 인스턴스를 가져와서 초기화합니다.
            if (form1 != null)
            {
                await Task.Delay(5000); // 5초 지연
                form1.InitializeTimer(); // 타이머 초기화 메서드 호출
                form1.ResetTimer(); // remainingTime 초기화 메서드 호출
                form1.randomchampion();
                form1.Show(); // 폼1 표시
            }
            this.Hide(); // 현재 폼 숨기기
        }

        private void Damage()
        {
            int totalDamage = 0;

            // 승리한 팀 확인
            var winningTeam = team1.Any(c => c.Health > 0) ? team1 : team2;

            // 남아 있는 챔피언 수를 계산
            foreach (var champion in winningTeam)
            {
                if (champion.Health > 0) // 살아 있는 챔피언인지 확인
                {
                    totalDamage += 2; // 남아 있는 챔피언마다 1의 데미지를 추가
                }
            }

            if (winningTeam == team1)
            {
                form2.lb_life.Text = (int.Parse(form2.lb_life.Text) - (5 + totalDamage)).ToString();
            }
            if (winningTeam == team2)
            {
                form1.lb_life.Text = (int.Parse(form1.lb_life.Text) - (5 + totalDamage)).ToString();
            }
        }
        private string RemoveNumberFromName(string name)
        {
            // 이름의 끝에서 숫자를 제거
            int i = name.Length - 1;
            while (i >= 0 && char.IsDigit(name[i]))
            {
                i--;
            }
            return name.Substring(0, i + 1); // 숫자를 제외한 부분을 반환
        }
        //시너지 적용
        private void ApplySynergyEffects(List<Champion> team)
        {
            // 챔피언 이름에서 숫자를 제거하고 중복 여부 확인
            var groupedChampions = team.GroupBy(c => RemoveNumberFromName(c.Name))
                                        .Select(g => new
                                        {
                                            Champion = g.First(),
                                            Count = g.Count()
                                        })
                                        .ToList();

            var lightChampions = groupedChampions.Where(g => g.Champion.Synergy == "Light").ToList();
            var darkChampions = groupedChampions.Where(g => g.Champion.Synergy == "Dark").ToList();

            // Light 시너지 처리
            if (lightChampions.Count >= 2)
            {
                int defenseBonus = 0;
                if (lightChampions.Count >= 6)
                {
                    defenseBonus = 35; // 6명일 때 방어력 증가
                }
                else if (lightChampions.Count >= 4)
                {
                    defenseBonus = 15; // 4명일 때 방어력 증가
                }
                else if (lightChampions.Count >= 2)
                {
                    defenseBonus = 10; // 2명일 때 방어력 증가
                }

                foreach (var championGroup in lightChampions)
                {
                    championGroup.Champion.Defense += defenseBonus; // 모든 챔피언에게 동일한 방어력 증가

                }
                AppendToLog($"빛의 인도자 {lightChampions.Count}시너지! 방어력 {defenseBonus} 증가!");
            }

            // Dark 시너지 처리
            if (darkChampions.Count >= 2)
            {
                int attackBonus = 0;
                if (darkChampions.Count >= 6)
                {
                    attackBonus = 25; // 6명일 때 공격력 증가    
                }
                else if (darkChampions.Count >= 4)
                {
                    attackBonus = 20; // 4명일 때 공격력 증가
                }
                else if (darkChampions.Count >= 2)
                {
                    attackBonus = 15; // 2명일 때 공격력 증가
                }

                foreach (var championGroup in darkChampions)
                {
                    championGroup.Champion.Attack += attackBonus; // 모든 챔피언에게 동일한 공격력 증가
                }
                AppendToLog($"어둠의 인도자 {darkChampions.Count}시너지! 공격력 {attackBonus} 증가!");
            }
        }





        private async Task ExecuteAttack(List<Champion> attackingTeam, List<Champion> defendingTeam)
        {
            foreach (var champion in attackingTeam)
            {
                // 현재 라운드에서 체력이 0이 아닌 챔피언만 공격
                if (champion.Health >= 0)
                {
                    var target = defendingTeam.FirstOrDefault(c => c.Health > 0);
                    if (target != null)
                    {
                        int damage = Math.Max(0, champion.Attack - target.Defense);
                        target.Health -= damage;
                        if (target.Health < 0) target.Health = 0;

                        AppendToLog($"{champion.Name}이(가) {target.Name}에게 {damage}의 피해를 입혔습니다.");

                        if (target.Health <= 0)
                        {
                            AppendToLog($"{target.Name}이(가) 쓰러졌습니다.");
                        }
                    }
                }
            }
        }

        private void RemoveDefeatedChampions(List<Champion> team)
        {
            var defeatedChampions = team.Where(c => c.Health <= 0).ToList();

            foreach (var champion in defeatedChampions)
            {
                // 이미지 삭제
                RemoveChampionImage(champion);

                // 팀에서 제거
                team.Remove(champion);
            }
        }

        private void RemoveChampionImage(Champion champion)
        {
            // 팀 1의 버튼(1~21)에서 챔피언의 버튼을 찾아서 배경 이미지를 지움
            for (int i = 0; i < 21; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null && button.BackgroundImage != null)
                {
                    var team1Champion = team1.FirstOrDefault(c => c.Name == champion.Name && c.Health <= 0);
                    if (team1Champion != null && CompareImages(button.BackgroundImage, team1Champion.Image_3D))
                    {
                        button.BackgroundImage = null;
                        break;
                    }
                }
            }

            // 팀 2의 버튼(22~42)에서 챔피언의 버튼을 찾아서 배경 이미지를 지움
            for (int i = 21; i < 42; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null && button.BackgroundImage != null)
                {
                    var team2Champion = team2.FirstOrDefault(c => c.Name == champion.Name && c.Health <= 0);
                    if (team2Champion != null && CompareImages(button.BackgroundImage, team2Champion.Image_3D))
                    {
                        button.BackgroundImage = null;
                        break;
                    }
                }
            }
        }

        // 공격 가능한 챔피언 필터링
        private List<Champion> GetAttackableChampions(List<Champion> team)
        {
            return team.Where(c => c.Health > 0).ToList();
        }


        private void LogTeamStatus(List<Champion> team, string teamName)
        {
            AppendToLog($"{teamName} 상태:");
            foreach (var champion in team)
            {
                if (champion.Health < 0)
                    champion.Health = 0;
                AppendToLog($"{champion.Name}: {champion.Health} HP");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StartBattle(); // 전투 시작
        }
        private void UpdateChampionImages()
        {
            // 팀 1 이미지 수집 (1~21번 버튼)
            var team1Images = new List<Image>(new Image[21]); // 21개 슬롯 초기화
            for (int i = 0; i < 21; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    team1Images[i] = button.BackgroundImage; // 배경 이미지 설정 (null 가능)
                }
            }

            form1.UpdateTeam1Images(team1Images); // 폼1에 이미지 전달

            // 팀 2 이미지 수집 (22~42번 버튼)
            var team2Images = new List<Image>(new Image[21]); // 21개 슬롯 초기화
            for (int i = 21; i < 42; i++)
            {
                var button = this.Controls.Find($"btn_field{i + 1}", true).FirstOrDefault() as Button;
                if (button != null)
                {
                    team2Images[i - 21] = button.BackgroundImage; // 배경 이미지 설정 (null 가능)
                }
            }

            form2.UpdateTeam2Images(team2Images); // 폼2에 이미지 전달
        }

        private void Start3_Load(object sender, EventArgs e)
        {
            if (SharedData.image2 == 1)
            {
                button2.BackgroundImage = Properties.Resources.돌돌이원본1;
                button3.BackgroundImage = Properties.Resources.돌돌이원본1;
            }
            else if (SharedData.image2 == 2)
            {
                button2.BackgroundImage = Properties.Resources.얼음원본1;
                button2.BackgroundImage = Properties.Resources.얼음원본1;
            }
            else if (SharedData.image2 == 3)
            {
                button2.BackgroundImage = Properties.Resources.모래원본1;
                button3.BackgroundImage = Properties.Resources.모래원본1;
            }
            else if (SharedData.image2 == 4)
            {
                button2.BackgroundImage = Properties.Resources.감시자원본1;
                button3.BackgroundImage = Properties.Resources.감시자원본1;
            }
        }
    }
}
