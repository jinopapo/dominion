using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace dominion
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.MoneyLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ActioLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BuyLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.START = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pictureBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pictureBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(660, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Money:";
            this.label1.Visible = false;
            // 
            // MoneyLabel
            // 
            this.MoneyLabel.AutoSize = true;
            this.MoneyLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MoneyLabel.Location = new System.Drawing.Point(734, 540);
            this.MoneyLabel.Name = "MoneyLabel";
            this.MoneyLabel.Size = new System.Drawing.Size(19, 20);
            this.MoneyLabel.TabIndex = 3;
            this.MoneyLabel.Text = "0";
            this.MoneyLabel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(658, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Action:";
            this.label3.Visible = false;
            // 
            // ActioLabel
            // 
            this.ActioLabel.AutoSize = true;
            this.ActioLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ActioLabel.Location = new System.Drawing.Point(734, 570);
            this.ActioLabel.Name = "ActioLabel";
            this.ActioLabel.Size = new System.Drawing.Size(19, 20);
            this.ActioLabel.TabIndex = 5;
            this.ActioLabel.Text = "1";
            this.ActioLabel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(682, 600);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Buy:";
            this.label5.Visible = false;
            // 
            // BuyLabel
            // 
            this.BuyLabel.AutoSize = true;
            this.BuyLabel.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BuyLabel.Location = new System.Drawing.Point(734, 600);
            this.BuyLabel.Name = "BuyLabel";
            this.BuyLabel.Size = new System.Drawing.Size(19, 20);
            this.BuyLabel.TabIndex = 7;
            this.BuyLabel.Text = "1";
            this.BuyLabel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 50);
            this.button1.TabIndex = 8;
            this.button1.Text = "同じサプライで再開";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(633, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 50);
            this.button2.TabIndex = 9;
            this.button2.Text = "別のサプライで再開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Controls.Add(this.pictureBox3);
            this.pictureBox2.Controls.Add(this.label7);
            this.pictureBox2.Controls.Add(this.label6);
            this.pictureBox2.Controls.Add(this.label4);
            this.pictureBox2.Controls.Add(this.label2);
            this.pictureBox2.Controls.Add(this.label8);
            this.pictureBox2.Controls.Add(this.label9);
            this.pictureBox2.Controls.Add(this.label10);
            this.pictureBox2.Controls.Add(this.label11);
            this.pictureBox2.Image = global::dominion.Properties.Resources._3_2;
            this.pictureBox2.Location = new System.Drawing.Point(149, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(778, 595);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Controls.Add(this.pictureBox4);
            this.pictureBox3.Image = global::dominion.Properties.Resources.pp_rn1_2;
            this.pictureBox3.Location = new System.Drawing.Point(270, 150);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(242, 175);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::dominion.Properties.Resources.s_ribbon0942;
            this.pictureBox4.Location = new System.Drawing.Point(90, 40);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 80);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(200, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 27);
            this.label7.TabIndex = 14;
            this.label7.Text = "あなた :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(200, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 27);
            this.label6.TabIndex = 13;
            this.label6.Text = "CPU1  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(400, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 27);
            this.label4.TabIndex = 12;
            this.label4.Text = "CPU2  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(400, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "CPU3  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(300, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 27);
            this.label8.TabIndex = 11;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(300, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 27);
            this.label9.TabIndex = 12;
            this.label9.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(500, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 27);
            this.label10.TabIndex = 13;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(500, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 27);
            this.label11.TabIndex = 14;
            this.label11.Text = "0";
            // 
            // START
            // 
            this.START.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.START.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.START.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(128)));
            this.START.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.START.Image = global::dominion.Properties.Resources.ishidatami;
            this.START.Location = new System.Drawing.Point(426, 294);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(244, 45);
            this.START.TabIndex = 1;
            this.START.Text = "START";
            this.START.UseVisualStyleBackColor = true;
            this.START.Click += new System.EventHandler(this.StartClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::dominion.Properties.Resources._61RmHTe9sPL;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1100, 694);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(933, 469);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 694);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BuyLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ActioLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MoneyLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.START);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pictureBox2.ResumeLayout(false);
            this.pictureBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pictureBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void setSupply(List<string> l)
        {
            for (int i = 0; i < 10; i++)
            {
                switch (l[i])
                {
                    case "地下貯蔵庫":
                        this.supply[i] = new Supply(Player[0], 2, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.地下貯蔵庫;
                        this.supply[i].text = "地下貯蔵庫　コスト2\n +1アクション \n手札から好きな枚数のカードを捨て札にする。\n捨て札１枚につき、カードを１枚引く。";
                        break;
                    case "市場":
                        this.supply[i] = new Supply(Player[0], 5, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.市場;
                        this.supply[i].text = "市場　コスト5\n +1 カードを引く\n +1 アクション \n +1 カードを購入 \n +1 コイン";
                        break;
                    case "民兵":
                        this.supply[i] = new Supply(Player[0], 4, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.民兵;
                        this.supply[i].text = "民兵　コスト4\n +2 コイン\n 他のプレイヤーは全員、自分の手札が3枚になるまで捨て札にする";
                        break;
                    case "鉱山":
                        this.supply[i] = new Supply(Player[0], 5, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.鉱山;
                        this.supply[i].text = "鉱山　コスト5\nあなたの手札の財宝カード１枚を廃棄する。\n廃棄した財宝よりもコストが最大３コイン多い財宝カード１枚を獲得し、あなたの手札に加える。";
                        break;
                    case "堀":
                        this.supply[i] = new Supply(Player[0], 2, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.堀;
                        this.supply[i].text = "堀　コスト2\n + 2カードを引く\n他のプレイヤーがアタックカードを使用した時、手札からこのカードを公開できる。\nそうした場合、あなたはそのアタックカードの影響を受けない。";
                        break;
                    case "鍛冶屋":
                        this.supply[i] = new Supply(Player[0], 4, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.鍛冶屋;
                        this.supply[i].text = "鍛冶屋　コスト4\n + 3カードを引く";
                        break;
                    case "村":
                        this.supply[i] = new Supply(Player[0], 3, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.村;
                        this.supply[i].text = "村　コスト3\n + 1カードを引く \n +2 アクション";
                        break;
                    case "木こり":
                        this.supply[i] = new Supply(Player[0], 3, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.木こり;
                        this.supply[i].text = "木こり　コスト3\n + 1カードを購入 \n +2 コイン";
                        break;
                    case "改築":
                        this.supply[i] = new Supply(Player[0], 4, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.改築;
                        this.supply[i].text = "改築　コスト4\n あなたの手札のカード１枚を廃棄する。\n廃棄したカードよりコストが最大２コイン多いカード１枚を獲得する。";
                        break;
                    case "工房":
                        this.supply[i] = new Supply(Player[0], 3, 10, this, "action");
                        this.supply[i].Image = global::dominion.Properties.Resources.工房;
                        this.supply[i].text = "工房　コスト3\n コスト最大４コインまでのカード１枚を獲得する。";
                        break;                      
                    default:
                        this.supply[i] = new Supply(Player[0], 0, 10, this, "action");
                        break;
                }
                this.supply[i].Location = new System.Drawing.Point(100 + 80 * (i % 5), 130 + 120 * (i / 5));
                this.supply[i].Size = new System.Drawing.Size(70, 110);
                this.supply[i].SizeMode = PictureBoxSizeMode.StretchImage;
                this.supply[i].Name = l[i];
                this.Controls.Add(this.supply[i]);
            }
            this.Controls.Add(Dis);
            this.呪い = new Supply(Player[0], 0, 12, this, "victory");
            this.呪い.Image = global::dominion.Properties.Resources.呪い;
            this.呪い.Location = new System.Drawing.Point(740, 10);
            this.呪い.Name = "呪い";
            this.呪い.Size = new System.Drawing.Size(70, 110);
            this.呪い.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(呪い);
            this.属州 = new dominion.Supply(Player[0], 8, 12, this, "victory");
            this.属州.Image = global::dominion.Properties.Resources.属州;
            this.属州.Location = new System.Drawing.Point(580, 10);
            this.属州.Name = "属州";
            this.属州.Size = new System.Drawing.Size(70, 110);
            this.属州.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(属州);
            this.公領 = new dominion.Supply(Player[0], 5, 12, this, "victory");
            this.公領.Image = global::dominion.Properties.Resources.公領;
            this.公領.Location = new System.Drawing.Point(500, 10);
            this.公領.Name = "公領";
            this.公領.Size = new System.Drawing.Size(70, 110);
            this.公領.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(公領);
            this.屋敷 = new dominion.Supply(Player[0], 2, 12, this, "victory");
            this.屋敷.Image = global::dominion.Properties.Resources.屋敷;
            this.屋敷.Location = new System.Drawing.Point(420, 10);
            this.屋敷.Name = "屋敷";
            this.屋敷.Size = new System.Drawing.Size(70, 110);
            this.屋敷.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(屋敷); 
            this.金貨 = new dominion.Supply(Player[0], 6, 30,this,"money");
            this.金貨.Image = global::dominion.Properties.Resources.金貨;
            this.金貨.Location = new System.Drawing.Point(260, 10);
            this.金貨.Name = "金貨";
            this.金貨.Size = new System.Drawing.Size(70, 110);
            this.金貨.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(金貨);
            this.銀貨 = new dominion.Supply(Player[0], 3, 40,this,"money");
            this.銀貨.Image = global::dominion.Properties.Resources.銀貨;
            this.銀貨.Location = new System.Drawing.Point(180, 10);
            this.銀貨.Name = "銀貨";
            this.銀貨.Size = new System.Drawing.Size(70, 110);
            this.銀貨.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(銀貨);
            this.銅貨 = new dominion.Supply(Player[0], 0, 42,this,"money");
            this.銅貨.Image = global::dominion.Properties.Resources.銅貨;
            this.銅貨.Location = new System.Drawing.Point(100, 10);
            this.銅貨.Name = "銅貨";
            this.銅貨.Size = new System.Drawing.Size(70, 110);
            this.銅貨.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Controls.Add(銅貨);
            label1.Visible = true;
            MoneyLabel.Visible = true;
            label3.Visible = true;
            ActioLabel.Visible = true;
            label5.Visible = true;
            BuyLabel.Visible = true;
        }

        internal void BuySuplly(string buysupply,Player p)
        {
            switch (buysupply)
            {
                case "属州":
                    属州.AddTrash(p);
                    break;
                case "公領":
                    公領.AddTrash(p);
                    break;
                case "屋敷":
                    屋敷.AddTrash(p);
                    break;
                case "金貨":
                    金貨.AddTrash(p);
                    break;
                case "銀貨":
                    銀貨.AddTrash(p);
                    break;
                case "銅貨":
                    銅貨.AddTrash(p);
                    break;
                default:
                    for (int i = 0; i < 10; i++)
                    {
                        if (supply[i].Name == buysupply)
                        {
                            supply[i].AddTrash(p);
                        }
                    }
                    break;
            }
        }

        internal int GetSupplyCount(string p)
        {
            int a = 0;
            switch (p)
            {
                case "属州":
                    a = 属州.GetCount();
                    break;
                case "公領":
                    a = 公領.GetCount();
                    break;
                case "屋敷":
                    a = 屋敷.GetCount();
                    break;
                case "金貨":
                    a = 金貨.GetCount();
                    break;
                case "銀貨":
                    a = 銀貨.GetCount();
                    break;
                case "銅貨":
                    a = 銅貨.GetCount();
                    break;
                default:
                    for (int i = 0; i < 10; i++)
                    {
                        if (supply[i].Name == p)
                        {
                            a = supply[i].GetCount();
                        }
                    }
                break;
            }
            return a;
        }

        internal void AllSupplyRefresh()
        {
            for (int i = 0; i < 10; i++)
            {
                supply[i].Refresh();
            }
            属州.Refresh();
            公領.Refresh();
            屋敷.Refresh();
            金貨.Refresh();
            銀貨.Refresh();
            銅貨.Refresh();
            呪い.Refresh();
        }

        internal void AllSupplyClickOff()
        {
            for (int i = 0; i < 10; i++)
            {
                supply[i].Enabled = false;
            }
            属州.Enabled = false;
            公領.Enabled = false;
            屋敷.Enabled = false;
            金貨.Enabled = false;
            銀貨.Enabled = false;
            銅貨.Enabled = false;
            呪い.Enabled = false;
        }

        internal void AllSupplyClickOn()
        {
            for (int i = 0; i < 10; i++)
            {
                supply[i].Enabled = true;
            }
            属州.Enabled = true;
            公領.Enabled = true;
            屋敷.Enabled = true;
            金貨.Enabled = true;
            銀貨.Enabled = true;
            銅貨.Enabled = true;
            呪い.Enabled = true;
        }

        internal bool EndGameFlag()
        {
            if (属州.GetCount() == 0 || SupplyCount() == 3)
            {
                return true;
            }
            return false;
        }

        internal void MineMode(int cost)
        {
            for (int i = 0; i < 10; i++)
            {
                if (supply[i].ShowType("money") && supply[i].GetCost() <= cost)
                {
                    supply[i].SupplyMineModeOn(cost);
                }
            }
            銅貨.SupplyMineModeOn(cost);
            if (3 <= cost)
            {
                銀貨.SupplyMineModeOn(cost);
            }
            if (6 <= cost)
            {
                金貨.SupplyMineModeOn(cost); 
            }
        }

        internal void MineModeOff(int cost)
        {
            for (int i = 0; i < 10; i++)
            {
                if (supply[i].ShowType("money") && supply[i].GetCost() <= cost)
                {
                    supply[i].SupplyMineModeOff();
                }
            }
            銅貨.SupplyMineModeOff();
            銀貨.SupplyMineModeOff();
            金貨.SupplyMineModeOff();
        }

        internal void AddTrashOn(int p)
        {
            for (int i = 0; i < 10; i++)
            {
                if (supply[i].GetCost() <= p)
                {
                    supply[i].AddTrashOn(p);
                }
            }
            銅貨.AddTrashOn(p);
            if (p >= 3)
            {
                銀貨.AddTrashOn(p);
            }
            if (p >= 6)
            {
                金貨.AddTrashOn(p);
            }
            if (p >= 2)
            {
                屋敷.AddTrashOn(p);
            }
            if (p >= 5)
            {
                公領.AddTrashOn(p);
            }
            if (p >= 8)
            {
                属州.AddTrashOn(p);
            }
        }

        internal void AddTrashOff(int p)
        {
            for (int i = 0; i < 10; i++)
            {
                if (supply[i].GetCost() <= p)
                {
                    supply[i].AddTrashOff();
                }
            }
            銅貨.AddTrashOff();
            if (p >= 3)
            {
                銀貨.AddTrashOff();
            }
            if (p >= 6)
            {
                金貨.AddTrashOff();
            }
            if (p >= 2)
            {
                屋敷.AddTrashOff();
            }
            if (p >= 5)
            {
                公領.AddTrashOff();
            }
            if (p >= 8)
            {
                属州.AddTrashOff();
            }
        }
        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button START;
        private Supply 銅貨;
        private Supply 銀貨;
        private Supply 屋敷;
        private Supply 金貨;
        private Supply 公領;
        private Supply 属州;
        private Supply 呪い;
        private Label label1;
        private Label MoneyLabel;
        private Label label3;
        private Label ActioLabel;
        private Label label5;
        private Label BuyLabel;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label2;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        public Label label12;
    }
}

