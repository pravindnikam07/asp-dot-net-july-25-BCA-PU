namespace CalculatorApp;

public partial class Form1 : Form
{
    TextBox inputBox1, inputBox2;
    Button add;

    Label output;

    public Form1()
    {
        InitializeComponent();
        CreateUI();
    }

    void CreateUI()
    {
        this.Width = 400;
        this.Height = 300;
        this.Text = "My Calculator App";
        this.BackColor = Color.AliceBlue;

        // Create a text box
        inputBox1 = new TextBox();
        inputBox1.Top = 40;
        inputBox1.Left = 50;
        // inputBox1.Enabled = false;      // this will disable the input in textbox.
        inputBox1.Enabled = true;          // this will enble the input in textbox.
        inputBox1.Width = 200;             // this will change the width of textbox.
        this.Controls.Add(inputBox1);      // this will add textbox to the form1

        // Creating a second text box
        inputBox2 = new TextBox();
        inputBox2.Top = 80;
        inputBox2.Left = 50;
        // inputBox2.Enabled = false;      // this will disable the input in textbox.
        inputBox2.Enabled = true;          // this will enble the input in textbox.
        inputBox2.Width = 200;             // this will change the width of textbox.
        this.Controls.Add(inputBox2);      // this will add textbox to the form1


        add = new Button();
        add.Text = "Add";
        add.Top = 120;
        add.Left = 50;
        add.Click += add_btn;
        this.Controls.Add(add);


        // creating label for showing output;
        output = new Label();
        output.Top = 160;
        output.Left = 50;
        output.Text = "Here is your output";
        this.Controls.Add(output);
    }

    void add_btn(object sender, EventArgs e)
    {
        int a = int.Parse(inputBox1.Text);
        int b = int.Parse(inputBox2.Text);
        output.Text = "Addition is " + (a + b);
    }

}
