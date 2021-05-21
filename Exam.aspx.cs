using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestDemo
{
    public partial class Exam : System.Web.UI.Page
    {
        int Number = 1;//To start question from 1.
        int Points = 0;//Total correct answers variable
        int value = 0;//to get value of which radio button clicked.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string Email = Session["Email"].ToString();
                    List<Tuple<string, string>> parameterList = new List<Tuple<string, string>>();
                    parameterList.Add(new Tuple<string, string>("@email", Email));
                    var data = SqlDataBind.GetDataByStoredProcedure("usp_SelectUserData", "ConnectionString", parameterList);
                    if (data.Tables[0].Rows.Count > 0)
                    {
                        ViewState["num"] = Convert.ToInt32(data.Tables[0].Rows[0]["Session"]);
                        int results = Convert.ToInt32(data.Tables[0].Rows[0]["Result"]);
                        int issubmit = Convert.ToInt32(data.Tables[0].Rows[0]["IsSubmit"]);
                        if (issubmit > 0)//Check whether user already submitted.
                        {
                            lblresult.Visible = true;
                            btnNext.Visible = false;
                            btnSubmit.Visible = false;
                            lblQuestion.Visible = false;
                            lblQNumber.Visible = false;
                            rboption1.Visible = false;
                            rboption2.Visible = false;
                            rboption3.Visible = false;
                            rboption4.Visible = false;
                            lblresult.Text = "Your Result is: " + results.ToString() + "/10";
                        }
                        else
                        {
                            BindQuestion(Convert.ToInt32(ViewState["num"]));
                            Points = results;
                            lblresult.Visible = false;
                        }
                    }
                    else
                    {
                        Points = Convert.ToInt32(Session["res"]);//if there is value in session variable then it assign to point then next flow continue from there.
                        ViewState["num"] = Number;
                        BindQuestion(Number);
                    }

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        private void BindQuestion(int Number)//To get question one by one on next button click
        {
            List<Tuple<string, string>> parameterList = new List<Tuple<string, string>>();
            parameterList.Add(new Tuple<string, string>("@Id", Number.ToString()));
            var data = SqlDataBind.GetDataByStoredProcedure("usp_GetQuestionsOneByOne", "ConnectionString", parameterList);
            if (data.Tables[0].Rows.Count > 0)
            {
                lblQNumber.InnerText = data.Tables[0].Rows[0]["QuestionID"].ToString() + ". ";
                lblQuestion.InnerText = data.Tables[0].Rows[0]["Question"].ToString();
                rboption1.Text = data.Tables[0].Rows[0]["Option1"].ToString();
                rboption2.Text = data.Tables[0].Rows[0]["Option2"].ToString();
                rboption3.Text = data.Tables[0].Rows[0]["Option3"].ToString();
                rboption4.Text = data.Tables[0].Rows[0]["Option4"].ToString();

            }
        }
        private void CheckAnswer(int Number)//to check answer of currect question binded in elements.
        {
            if (rboption1.Checked == true)
                value = 1;
            else if (rboption2.Checked == true)
                value = 2;
            else if (rboption3.Checked == true)
                value = 3;
            else if (rboption4.Checked == true)
                value = 4;
            List<Tuple<string, string>> parameterList = new List<Tuple<string, string>>();
            parameterList.Add(new Tuple<string, string>("@Id", Number.ToString()));
            var data = SqlDataBind.GetDataByStoredProcedure("usp_GetQuestionsOneByOne", "ConnectionString", parameterList);
            if (data.Tables[0].Rows.Count > 0)
            {
                string answer = data.Tables[0].Rows[0]["Answer"].ToString();
                if (value == Convert.ToInt32(answer))//Check whether database and user selected answer match?
                {
                    Points = Convert.ToInt32(Session["res"]) + 1;//Correct
                }
                else
                {
                    Points = Convert.ToInt32(Session["res"]);//incorrect
                }
                Session["res"] = Points;//assign point to session because page is going to load again and again
                rboption1.Checked = false;
                rboption2.Checked = false;
                rboption3.Checked = false;
                rboption4.Checked = false;
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            int Number = Convert.ToInt32(ViewState["num"]) + 1;//To bind next question increment num by 1.
            if (Number > 10)//There are only 10 questions to be inserted in db so matched Number with 10.
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "alert('No more Question Please submit');", true);
            }
            else
            {
                BindQuestion(Number);
                CheckAnswer(Convert.ToInt32(ViewState["num"]));
                ViewState["num"] = Number;


            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckAnswer(Convert.ToInt32(ViewState["num"]));//to check last question binded answer with database answer
            string Email = Session["Email"].ToString();
            int ressubmit = Convert.ToInt32(Session["res"]);//stores final score to insert in db
            List<Tuple<string, string>> parametersList = new List<Tuple<string, string>>();
            parametersList.Add(new Tuple<string, string>("@email", Email));
            parametersList.Add(new Tuple<string, string>("@result", ressubmit.ToString()));
            var data = SqlDataBind.SaveDataByStoredProcedure("usp_UpdateResultData", "ConnectionString", parametersList);
            if (data > 0)
            {
                lblresult.Visible = true;
                btnNext.Visible = false;
                btnSubmit.Visible = false;
                lblQuestion.Visible = false;
                lblQNumber.Visible = false;
                rboption1.Visible = false;
                rboption2.Visible = false;
                rboption3.Visible = false;
                rboption4.Visible = false;
                lblresult.Text = "Your Result is: " + ressubmit.ToString() + "/10";

            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            CheckAnswer(Convert.ToInt32(ViewState["num"]));
            int Number = Convert.ToInt32(ViewState["num"]);
            int result = Convert.ToInt32(Session["res"]);
            string Email = Session["Email"].ToString();
            List<Tuple<string, string>> parametersList = new List<Tuple<string, string>>();
            parametersList.Add(new Tuple<string, string>("@session", Number.ToString()));
            parametersList.Add(new Tuple<string, string>("@result", result.ToString()));
            parametersList.Add(new Tuple<string, string>("@email", Email));

            var data = SqlDataBind.SaveDataByStoredProcedure("usp_UpdateSessionData", "ConnectionString", parametersList);//store all values because if this user comes back then get him/her to directly there where he left.
            if (data > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "alert('Logout successfully');", true);
                Session["Email"] = null;
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
    }
}