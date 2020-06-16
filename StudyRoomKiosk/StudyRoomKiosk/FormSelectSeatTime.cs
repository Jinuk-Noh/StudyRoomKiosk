﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyRoomKiosk
{
    public partial class FormSelectSeatTime : Form
    {
        Sql sql = new Sql();
        string selectTime = null;
        String[] seatNo;
        DateTime[] time;
        DateTime[] timEnd;
        int count;
        public FormSelectSeatTime()
        {
            InitializeComponent();
            rbText();
            //whoIs();
            //seatStatus();
            //SeatNoTime();

            //we_ TBL_TIME에 저장된 데이터를 불러와서 라디오버튼의 텍스트로 대입하도록 수정 필요.. 추후 데이터 수정시 용이하도록.
            //groupBox_seat 내 모든 버튼에 대한 클릭 이벤트 설정
            foreach (Button seatButton in groupBox_seat.Controls.OfType<Button>())
            {
                seatButton.Click += seat_Click;
            }
            button_goJoin.Visible = false;
        }

        //time테이블에 저장된 시간과 가격 값을 가져와 라디오버튼의 텍스트값에 대입.
        private void rbText()
        {
            DataSet ds = sql.Query_Select_DataSet("*", "", "TBL_TIME");
            RadioButton[] todayRbtn = new RadioButton[6];
            RadioButton[] longRbtn = new RadioButton[6];
            int todayP = 0;
            int longP = 0;

            for (int i = 0; i < 6; i++)
            {
                todayRbtn[i] = new RadioButton();
                todayP = int.Parse(ds.Tables[0].Rows[i]["amount"].ToString());
                todayRbtn[i].Text = ds.Tables[0].Rows[i]["timeUse"].ToString() + " / " + string.Format("{0:n0}", todayP);
                todayRbtn[i].Size = new Size(178, 25);
                todayRbtn[i].Location = new Point(7 + i % 3 * todayRbtn[i].Width, 23 + i / 3 * todayRbtn[i].Height);

                longRbtn[i] = new RadioButton();
                longP = int.Parse(ds.Tables[0].Rows[i + 6]["amount"].ToString());
                longRbtn[i].Text = ds.Tables[0].Rows[i + 6]["timeUse"].ToString() + " / " + string.Format("{0:n0}", longP);
                longRbtn[i].Size = new Size(178, 25);
                longRbtn[i].Location = new Point(7 + i % 3 * todayRbtn[i].Width, 23 + i / 3 * todayRbtn[i].Height);

                groupBox_today.Controls.Add(todayRbtn[i]);
                groupBox_long.Controls.Add(longRbtn[i]);
            }
        }

        //남은 시간 구하는 메소드
        private void SeatNoTime()
        {
            //사용중인 좌석 개수를 구한다.
            DataSet ds = sql.Query_Select_DataSet("seatNo,expiredTime", " Where seatNo is not null", "TBL_MEMBER");
            count = int.Parse(ds.Tables[0].Rows.Count.ToString());
            //사용중인 좌석 수 많큼 배열을 준다.
            seatNo = new String[count];
            time = new DateTime[count];
            timEnd = new DateTime[count];
            for (int i = 0; i < count; i++)
            {
                //사용 중인 좌석 번호값을 배열에 넣는다.
                seatNo[i] = ds.Tables[0].Rows[i]["seatNo"].ToString();
                //사용자의 종료시간을 구한다.
                timEnd[i] = Convert.ToDateTime(ds.Tables[0].Rows[i]["expiredTime"].ToString());
                DateTime timeNow = DateTime.Now;
                // 시간 차이 구함
                //남은시간 = 종료시간 -  현재 시간

                if (timEnd[i] > timeNow)
                {
                    TimeSpan gapTime2 = timEnd[i] - timeNow;
                    //TimeSpan gapTime2 = eTime - time;
                    //계산한 남은 시간을 배열에 넣어준다.
                    time[i] = Convert.ToDateTime((gapTime2.ToString()));
                }
            }
            label_time();
            //   label_time1.Text = time[0].ToString().Substring(13, 5);

        }
        //사용중인 자리 이벤트
        private void label_time()
        {
            for (int i = 0; i < count; i++)
            {
                DateTime timeNow = DateTime.Now;


                if (timEnd[i] > timeNow)
                {
                    switch (seatNo[i])
                    {
                        case "1":
                            label_time1.Visible = true;
                            label_time1.Text = time[i].ToString().Substring(13, 5);
                            button_seat1.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat1.Enabled = false;
                            break;
                        case "2":
                            label_time2.Visible = true;
                            label_time2.Text = time[i].ToString().Substring(13, 5);
                            button_seat2.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat2.Enabled = false;
                            break;
                        case "3":
                            label_time3.Visible = true;
                            label_time3.Text = time[i].ToString().Substring(13, 5);
                            button_seat3.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat3.Enabled = false;
                            break;
                        case "4":
                            label_time4.Visible = true;
                            label_time4.Text = time[i].ToString().Substring(13, 5);
                            button_seat4.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat4.Enabled = false;
                            break;
                        case "5":
                            label_time5.Visible = true;
                            label_time5.Text = time[i].ToString().Substring(13, 5);
                            button_seat5.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat5.Enabled = false;
                            break;
                        case "6":
                            label_time6.Visible = true;
                            label_time6.Text = time[i].ToString().Substring(13, 5);
                            button_seat6.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat6.Enabled = false;
                            break;
                        case "7":
                            label_time7.Visible = true;
                            label_time7.Text = time[i].ToString().Substring(13, 5);
                            button_seat7.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat7.Enabled = false;
                            break;
                        case "8":
                            label_time8.Visible = true;
                            label_time8.Text = time[i].ToString().Substring(13, 5);
                            button_seat8.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat8.Enabled = false;
                            break;
                        case "9":
                            label_time9.Visible = true;
                            label_time9.Text = time[i].ToString().Substring(13, 5);
                            button_seat9.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat9.Enabled = false;
                            break;
                        case "10":
                            label_time10.Visible = true;
                            label_time10.Text = time[i].ToString().Substring(13, 5);
                            button_seat10.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat10.Enabled = false;
                            break;
                        case "11":
                            label_time11.Visible = true;
                            label_time11.Text = time[i].ToString().Substring(13, 5);
                            button_seat11.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat11.Enabled = false;
                            break;
                        case "12":
                            label_time12.Visible = true;
                            label_time12.Text = time[i].ToString().Substring(13, 5);
                            button_seat12.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat12.Enabled = false;
                            break;
                        case "13":
                            label_time13.Visible = true;
                            label_time13.Text = time[i].ToString().Substring(13, 5);
                            button_seat13.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat13.Enabled = false;
                            break;
                        case "14":
                            label_time14.Visible = true;
                            label_time14.Text = time[i].ToString().Substring(13, 5);
                            button_seat14.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat14.Enabled = false;
                            break;
                        case "15":
                            label_time15.Visible = true;
                            label_time15.Text = time[i].ToString().Substring(13, 5);
                            button_seat15.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat15.Enabled = false;
                            break;
                        case "16":
                            label_time16.Visible = true;
                            label_time16.Text = time[i].ToString().Substring(13, 5);
                            button_seat16.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat16.Enabled = false;
                            break;
                        case "17":
                            label_time17.Visible = true;
                            label_time17.Text = time[i].ToString().Substring(13, 5);
                            button_seat17.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat17.Enabled = false;
                            break;
                        case "18":
                            label_time18.Visible = true;
                            label_time18.Text = time[i].ToString().Substring(13, 5);
                            button_seat18.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat18.Enabled = false;
                            break;
                        case "19":
                            label_time19.Visible = true;
                            label_time19.Text = time[i].ToString().Substring(13, 5);
                            button_seat19.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat19.Enabled = false;
                            break;
                        case "20":
                            label_time20.Visible = true;
                            label_time20.Text = time[i].ToString().Substring(13, 5);
                            button_seat20.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat20.Enabled = false;
                            break;
                        case "21":
                            label_time21.Visible = true;
                            label_time21.Text = time[i].ToString().Substring(13, 5);
                            button_seat21.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat21.Enabled = false;
                            break;
                        case "22":
                            label_time22.Visible = true;
                            label_time22.Text = time[i].ToString().Substring(13, 5);
                            button_seat22.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat22.Enabled = false;
                            break;
                        case "23":
                            label_time23.Visible = true;
                            label_time23.Text = time[i].ToString().Substring(13, 5);
                            button_seat23.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat23.Enabled = false;
                            break;
                        case "24":
                            label_time24.Visible = true;
                            label_time24.Text = time[i].ToString().Substring(13, 5);
                            button_seat24.BackColor = Color.FromArgb(255, 128, 0);
                            button_seat24.Enabled = false;
                            break;

                    }

                }
            }
        }
        //자리 선택 시 수행될 메소드
        private void seat_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            //자리를 이미 선택해 둔 상태에서 다른 자리 선택시 기 선택 자리 색상 초기화
            foreach (Button seatButton in groupBox_seat.Controls.OfType<Button>())
            {
                if (seatButton.BackColor == Color.FromArgb(255, 220, 0))
                {
                    seatButton.BackColor = Color.FromArgb(255, 255, 255);
                }
            }
            //선택한 자리 색상 변경
            clickedButton.BackColor = Color.FromArgb(255, 220, 0);
            TblMember.seatNo = clickedButton.Text;  //선택한 자리번호 저장
        }

        //시간은 당일과 장기 이용권 중 하나만 선택 되어야 하므로 클릭시 다른 그룹박스의 클릭 해제
        private void groupBox_longTime_Enter(object sender, EventArgs e)
        {
            foreach (RadioButton todayRButton in groupBox_today.Controls.OfType<RadioButton>())
            {
                todayRButton.Checked = false;
            }
        }

        //시간은 당일과 장기 이용권 중 하나만 선택 되어야 하므로 클릭시 다른 그룹박스의 클릭 해제
        private void groupBox_today_Enter(object sender, EventArgs e)
        {
            foreach (RadioButton longTimeRButton in groupBox_long.Controls.OfType<RadioButton>())
            {
                longTimeRButton.Checked = false;
            }
        }

        //비회원 입장시 장기이용권 결제 못하도록 하는 메소드
        private void whoIs()
        {
            //비회원 입장일 경우
            //장기 이용권 그룹박스 텍스트 내용 변경, 박스 내 라디오 버튼 클릭 비활성화, 클릭 시 가입여부 팝업 이벤트 호출
            if (Sql.pageType == 1)
            {
                button_goJoin.Visible = true;
                groupBox_long.Text = "장기 이용권 _ 정회원만 선택 가능합니다.";

                //groupBox_longTime 내 모든 라디오 버튼에 대해 비활성화.
                //그룹박스 자체를 비활성화 하면 혹시라도 클릭시 메시지박스가 팝업되도록 할 수 없으므로 아래와 같이 처리
                foreach (RadioButton longTimeRButton in groupBox_long.Controls.OfType<RadioButton>())
                {
                    longTimeRButton.Enabled = false;
                }
            }
            groupBox_long.Click += unableClick;
        }

        //비회원 입장 후 장기이용권 클릭 시 가입여부 팝업 이벤트
        private void unableClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("장기 이용권은 정회원만 선택 가능합니다. \n회원가입 하시겠습니까?", "장기 이용권 안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormMembersJoin form = new FormMembersJoin();
                this.Visible = false;
                form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                form.ShowDialog();
                Process.GetCurrentProcess().Kill();
            }
        }

        private string EndTime()
        {
            DateTime time = DateTime.Now;
            double t = 0;
            if (selectTime == "종일")
            {
                time.AddDays(1);
            }
            else if (selectTime.Contains("시간"))
            {
                t = Convert.ToDouble(selectTime.Substring(0, 1));
                time.AddHours(t);
            }
            else if (selectTime.Contains("일"))
            {
                t = Convert.ToDouble(selectTime.Substring(0, 1));
                time.AddDays(t);
            }
            else if (selectTime.Contains("주"))
            {
                t = Convert.ToDouble(selectTime.Substring(0, 1)) * 7;
                time.AddDays(t);
            }
            return time.ToString("yyyy-MM-dd HH:mm");
        }

        //결제 후 DB에 데이터 저장
        private void updateMember()
        {
            //TBL_MEMBER에 데이터 저장
            if (Sql.pageType == 0)   //회원 입장
            {
                sql.Query_Modify("UPDATE TBL_MEMBER SET seatNo = " + TblMember.seatNo + "expiredTime = " + EndTime() +
                                 "where phoneNum = " + TblMember.phoneNum);
            }
            if (Sql.pageType == 1)   //비회원 입장
            {
                if (sql.Query_Select_Bool("TBL_MEMBER", "memberNo > 0"))
                {
                    int maxNum = int.Parse(sql.Query_Select_DataSet("MAX(memberNo) as MAX", "", "TBL_MEMBER").Tables[0].Rows[0]["MAX"].ToString());
                    maxNum += 1;
                    sql.Query_Modify("INSERT INTO TBL_MEMBER ( memberNo, phoneNum, memberbool) VALUES (" + maxNum + ",'" + TblMember.phoneNum + "','" + false + "')");
                }
                else
                {
                    sql.Query_Modify("INSERT INTO TBL_MEMBER ( memberNo, phoneNum, memberbool) VALUES (1,'" + TblMember.phoneNum + "','" + false + "')");
                }
            }
            //TBL_SEAT에 데이터 저장
            sql.Query_Modify("UPDATE TBL_SEAT SET state = 1 where seatNo = " + TblMember.seatNo);
        }

        //결제하기 버튼 클릭시 결제 진행
        private void button_payment_Click(object sender, EventArgs e)
        {
            foreach (RadioButton radioButton in groupBox_long.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    selectTime = radioButton.Text;
                }
            }

            foreach (RadioButton radioButton in groupBox_today.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    selectTime = radioButton.Text;
                }
            }

            //we_selectTime에 클릭한 라디오버튼의 텍스트값 저장___해결
            if (TblMember.seatNo == null || selectTime == null)
            {
                MessageBox.Show("시간과 좌석 모두 선택해야 합니다.");
            }
            else
            {
                string str = "좌석 : " + TblMember.seatNo + "\n시간 : " + selectTime + "\n결제하시겠습니까?";
                if (MessageBox.Show(str, "결제정보", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //we_결제기능 추후 구현 필요
                    MessageBox.Show("결제되었습니다.\n입장하십시오.");
                    updateMember();

                    FormMembersEnt form = new FormMembersEnt();
                    this.Visible = false;
                    form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    form.ShowDialog();
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    MessageBox.Show("결제가 취소되었습니다.");
                }
            }
        }

        //처음으로 버튼 클릭시 해당 폼으로 이동
        private void button_goHome_Click(object sender, EventArgs e)
        {
            FormMembersEnt form = new FormMembersEnt();
            this.Visible = false;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ShowDialog();
            Process.GetCurrentProcess().Kill();
        }

        //회원가입 버튼 클릭시 해당 폼으로 이동
        private void button_goJoin_Click(object sender, EventArgs e)
        {
            FormMembersJoin form = new FormMembersJoin();
            this.Visible = false;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.ShowDialog();
            Process.GetCurrentProcess().Kill();
        }
        //1분 마다 발생 되는 이벤트
        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime timeNow = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                if (timEnd[i] > timeNow)
                {
                    TimeSpan ts = new TimeSpan(0, 1, 0);
                    time[i] -= ts;
                    label_time();
                }
            }
        }

       
    }
}
