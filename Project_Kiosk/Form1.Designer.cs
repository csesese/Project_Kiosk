﻿
namespace Project_Kiosk
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel_coffee = new System.Windows.Forms.Panel();
            this.Btn_vanila = new System.Windows.Forms.Button();
            this.Btn_espresso = new System.Windows.Forms.Button();
            this.Btn_cappuccino = new System.Windows.Forms.Button();
            this.Btn_moca = new System.Windows.Forms.Button();
            this.Btn_latte = new System.Windows.Forms.Button();
            this.Btn_Americano = new System.Windows.Forms.Button();
            this.Panel_Juice = new System.Windows.Forms.Panel();
            this.Btn_Tea3 = new System.Windows.Forms.Button();
            this.Btn_Tea5 = new System.Windows.Forms.Button();
            this.Btn_Tea4 = new System.Windows.Forms.Button();
            this.Btn_juice1 = new System.Windows.Forms.Button();
            this.Btn_Tea2 = new System.Windows.Forms.Button();
            this.Btn_juice2 = new System.Windows.Forms.Button();
            this.Btn_juice3 = new System.Windows.Forms.Button();
            this.Btn_Tea1 = new System.Windows.Forms.Button();
            this.Panel_etc = new System.Windows.Forms.Panel();
            this.Btn_etc6 = new System.Windows.Forms.Button();
            this.Btn_shot = new System.Windows.Forms.Button();
            this.Btn_syrup = new System.Windows.Forms.Button();
            this.Btn_etc4 = new System.Windows.Forms.Button();
            this.Btn_etc1 = new System.Windows.Forms.Button();
            this.Btn_etc5 = new System.Windows.Forms.Button();
            this.Btn_etc3 = new System.Windows.Forms.Button();
            this.Btn_etc2 = new System.Windows.Forms.Button();
            this.Btn_afogato = new System.Windows.Forms.Button();
            this.Panel_bakery = new System.Windows.Forms.Panel();
            this.Btn_bagel = new System.Windows.Forms.Button();
            this.Btn_makarong = new System.Windows.Forms.Button();
            this.Btn_honey = new System.Windows.Forms.Button();
            this.Btn_coffee = new System.Windows.Forms.Button();
            this.Btn_juice = new System.Windows.Forms.Button();
            this.Btn_etc = new System.Windows.Forms.Button();
            this.Btn_bakery = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Order = new System.Windows.Forms.Button();
            this.Panel_add_c = new System.Windows.Forms.Panel();
            this.count = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_cart = new System.Windows.Forms.Button();
            this.Btn_back = new System.Windows.Forms.Button();
            this.Btn_syrup3 = new System.Windows.Forms.Button();
            this.Btn_syrup2 = new System.Windows.Forms.Button();
            this.Btn_addsyrup = new System.Windows.Forms.Button();
            this.Btn_hot = new System.Windows.Forms.Button();
            this.Btn_ice = new System.Windows.Forms.Button();
            this.Bnt_addshot = new System.Windows.Forms.Button();
            this.Panel_coffee.SuspendLayout();
            this.Panel_Juice.SuspendLayout();
            this.Panel_etc.SuspendLayout();
            this.Panel_bakery.SuspendLayout();
            this.Panel_add_c.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_coffee
            // 
            this.Panel_coffee.Controls.Add(this.Btn_vanila);
            this.Panel_coffee.Controls.Add(this.Btn_espresso);
            this.Panel_coffee.Controls.Add(this.Btn_cappuccino);
            this.Panel_coffee.Controls.Add(this.Btn_moca);
            this.Panel_coffee.Controls.Add(this.Btn_latte);
            this.Panel_coffee.Controls.Add(this.Btn_Americano);
            this.Panel_coffee.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Panel_coffee.Location = new System.Drawing.Point(32, 42);
            this.Panel_coffee.Name = "Panel_coffee";
            this.Panel_coffee.Size = new System.Drawing.Size(360, 324);
            this.Panel_coffee.TabIndex = 0;
            // 
            // Btn_vanila
            // 
            this.Btn_vanila.Location = new System.Drawing.Point(134, 99);
            this.Btn_vanila.Name = "Btn_vanila";
            this.Btn_vanila.Size = new System.Drawing.Size(87, 60);
            this.Btn_vanila.TabIndex = 5;
            this.Btn_vanila.Text = "바닐라 라떼";
            this.Btn_vanila.UseVisualStyleBackColor = true;
            this.Btn_vanila.Click += new System.EventHandler(this.Btn_CoffeeDetail_Click);
            // 
            // Btn_espresso
            // 
            this.Btn_espresso.Location = new System.Drawing.Point(245, 99);
            this.Btn_espresso.Name = "Btn_espresso";
            this.Btn_espresso.Size = new System.Drawing.Size(87, 60);
            this.Btn_espresso.TabIndex = 4;
            this.Btn_espresso.Text = "에스프레소";
            this.Btn_espresso.UseVisualStyleBackColor = true;
            this.Btn_espresso.Click += new System.EventHandler(this.Btn_CoffeeDetail_Click);
            // 
            // Btn_cappuccino
            // 
            this.Btn_cappuccino.Location = new System.Drawing.Point(245, 21);
            this.Btn_cappuccino.Name = "Btn_cappuccino";
            this.Btn_cappuccino.Size = new System.Drawing.Size(87, 60);
            this.Btn_cappuccino.TabIndex = 3;
            this.Btn_cappuccino.Text = "카푸치노";
            this.Btn_cappuccino.UseVisualStyleBackColor = true;
            this.Btn_cappuccino.Click += new System.EventHandler(this.Btn_CoffeeDetail_Click);
            // 
            // Btn_moca
            // 
            this.Btn_moca.Location = new System.Drawing.Point(20, 99);
            this.Btn_moca.Name = "Btn_moca";
            this.Btn_moca.Size = new System.Drawing.Size(87, 60);
            this.Btn_moca.TabIndex = 2;
            this.Btn_moca.Text = "카페모카";
            this.Btn_moca.UseVisualStyleBackColor = true;
            this.Btn_moca.Click += new System.EventHandler(this.Btn_CoffeeDetail_Click);
            // 
            // Btn_latte
            // 
            this.Btn_latte.Location = new System.Drawing.Point(134, 21);
            this.Btn_latte.Name = "Btn_latte";
            this.Btn_latte.Size = new System.Drawing.Size(87, 60);
            this.Btn_latte.TabIndex = 1;
            this.Btn_latte.Text = "카페라떼";
            this.Btn_latte.UseVisualStyleBackColor = true;
            this.Btn_latte.Click += new System.EventHandler(this.Btn_CoffeeDetail_Click);
            // 
            // Btn_Americano
            // 
            this.Btn_Americano.Location = new System.Drawing.Point(20, 21);
            this.Btn_Americano.Name = "Btn_Americano";
            this.Btn_Americano.Size = new System.Drawing.Size(87, 60);
            this.Btn_Americano.TabIndex = 0;
            this.Btn_Americano.Text = "아메리카노";
            this.Btn_Americano.UseVisualStyleBackColor = true;
            this.Btn_Americano.Click += new System.EventHandler(this.Btn_CoffeeDetail_Click);
            // 
            // Panel_Juice
            // 
            this.Panel_Juice.Controls.Add(this.Btn_Tea3);
            this.Panel_Juice.Controls.Add(this.Btn_Tea5);
            this.Panel_Juice.Controls.Add(this.Btn_Tea4);
            this.Panel_Juice.Controls.Add(this.Btn_juice1);
            this.Panel_Juice.Controls.Add(this.Btn_Tea2);
            this.Panel_Juice.Controls.Add(this.Btn_juice2);
            this.Panel_Juice.Controls.Add(this.Btn_juice3);
            this.Panel_Juice.Controls.Add(this.Btn_Tea1);
            this.Panel_Juice.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Panel_Juice.Location = new System.Drawing.Point(942, 488);
            this.Panel_Juice.Name = "Panel_Juice";
            this.Panel_Juice.Size = new System.Drawing.Size(360, 324);
            this.Panel_Juice.TabIndex = 7;
            this.Panel_Juice.Visible = false;
            // 
            // Btn_Tea3
            // 
            this.Btn_Tea3.Location = new System.Drawing.Point(19, 175);
            this.Btn_Tea3.Name = "Btn_Tea3";
            this.Btn_Tea3.Size = new System.Drawing.Size(87, 60);
            this.Btn_Tea3.TabIndex = 4;
            this.Btn_Tea3.Text = "얼그레이";
            this.Btn_Tea3.UseVisualStyleBackColor = true;
            // 
            // Btn_Tea5
            // 
            this.Btn_Tea5.Location = new System.Drawing.Point(133, 174);
            this.Btn_Tea5.Name = "Btn_Tea5";
            this.Btn_Tea5.Size = new System.Drawing.Size(87, 60);
            this.Btn_Tea5.TabIndex = 7;
            this.Btn_Tea5.Text = "밀크티";
            this.Btn_Tea5.UseVisualStyleBackColor = true;
            // 
            // Btn_Tea4
            // 
            this.Btn_Tea4.Location = new System.Drawing.Point(19, 99);
            this.Btn_Tea4.Name = "Btn_Tea4";
            this.Btn_Tea4.Size = new System.Drawing.Size(87, 60);
            this.Btn_Tea4.TabIndex = 6;
            this.Btn_Tea4.Text = "로즈마리";
            this.Btn_Tea4.UseVisualStyleBackColor = true;
            // 
            // Btn_juice1
            // 
            this.Btn_juice1.Location = new System.Drawing.Point(19, 21);
            this.Btn_juice1.Name = "Btn_juice1";
            this.Btn_juice1.Size = new System.Drawing.Size(87, 60);
            this.Btn_juice1.TabIndex = 0;
            this.Btn_juice1.Text = "딸기주스";
            this.Btn_juice1.UseVisualStyleBackColor = true;
            // 
            // Btn_Tea2
            // 
            this.Btn_Tea2.Location = new System.Drawing.Point(133, 99);
            this.Btn_Tea2.Name = "Btn_Tea2";
            this.Btn_Tea2.Size = new System.Drawing.Size(87, 60);
            this.Btn_Tea2.TabIndex = 5;
            this.Btn_Tea2.Text = "녹차";
            this.Btn_Tea2.UseVisualStyleBackColor = true;
            // 
            // Btn_juice2
            // 
            this.Btn_juice2.Location = new System.Drawing.Point(133, 21);
            this.Btn_juice2.Name = "Btn_juice2";
            this.Btn_juice2.Size = new System.Drawing.Size(87, 60);
            this.Btn_juice2.TabIndex = 1;
            this.Btn_juice2.Text = "키위주스";
            this.Btn_juice2.UseVisualStyleBackColor = true;
            // 
            // Btn_juice3
            // 
            this.Btn_juice3.Location = new System.Drawing.Point(247, 21);
            this.Btn_juice3.Name = "Btn_juice3";
            this.Btn_juice3.Size = new System.Drawing.Size(87, 60);
            this.Btn_juice3.TabIndex = 3;
            this.Btn_juice3.Text = "바나나주스";
            this.Btn_juice3.UseVisualStyleBackColor = true;
            // 
            // Btn_Tea1
            // 
            this.Btn_Tea1.Location = new System.Drawing.Point(247, 99);
            this.Btn_Tea1.Name = "Btn_Tea1";
            this.Btn_Tea1.Size = new System.Drawing.Size(87, 60);
            this.Btn_Tea1.TabIndex = 2;
            this.Btn_Tea1.Text = "캐모마일";
            this.Btn_Tea1.UseVisualStyleBackColor = true;
            // 
            // Panel_etc
            // 
            this.Panel_etc.Controls.Add(this.Btn_etc6);
            this.Panel_etc.Controls.Add(this.Btn_shot);
            this.Panel_etc.Controls.Add(this.Btn_syrup);
            this.Panel_etc.Controls.Add(this.Btn_etc4);
            this.Panel_etc.Controls.Add(this.Btn_etc1);
            this.Panel_etc.Controls.Add(this.Btn_etc5);
            this.Panel_etc.Controls.Add(this.Btn_etc3);
            this.Panel_etc.Controls.Add(this.Btn_etc2);
            this.Panel_etc.Controls.Add(this.Btn_afogato);
            this.Panel_etc.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Panel_etc.Location = new System.Drawing.Point(897, 158);
            this.Panel_etc.Name = "Panel_etc";
            this.Panel_etc.Size = new System.Drawing.Size(360, 324);
            this.Panel_etc.TabIndex = 15;
            this.Panel_etc.Visible = false;
            // 
            // Btn_etc6
            // 
            this.Btn_etc6.Location = new System.Drawing.Point(246, 176);
            this.Btn_etc6.Name = "Btn_etc6";
            this.Btn_etc6.Size = new System.Drawing.Size(86, 58);
            this.Btn_etc6.TabIndex = 15;
            this.Btn_etc6.Text = "유자 스파클링";
            this.Btn_etc6.UseVisualStyleBackColor = true;
            // 
            // Btn_shot
            // 
            this.Btn_shot.Location = new System.Drawing.Point(133, 23);
            this.Btn_shot.Name = "Btn_shot";
            this.Btn_shot.Size = new System.Drawing.Size(86, 58);
            this.Btn_shot.TabIndex = 7;
            this.Btn_shot.Text = "샷 추가";
            this.Btn_shot.UseVisualStyleBackColor = true;
            // 
            // Btn_syrup
            // 
            this.Btn_syrup.Location = new System.Drawing.Point(18, 23);
            this.Btn_syrup.Name = "Btn_syrup";
            this.Btn_syrup.Size = new System.Drawing.Size(86, 58);
            this.Btn_syrup.TabIndex = 8;
            this.Btn_syrup.Text = "시럽 추가";
            this.Btn_syrup.UseVisualStyleBackColor = true;
            // 
            // Btn_etc4
            // 
            this.Btn_etc4.Location = new System.Drawing.Point(18, 98);
            this.Btn_etc4.Name = "Btn_etc4";
            this.Btn_etc4.Size = new System.Drawing.Size(87, 60);
            this.Btn_etc4.TabIndex = 13;
            this.Btn_etc4.Text = "망고스무디";
            this.Btn_etc4.UseVisualStyleBackColor = true;
            // 
            // Btn_etc1
            // 
            this.Btn_etc1.Location = new System.Drawing.Point(132, 176);
            this.Btn_etc1.Name = "Btn_etc1";
            this.Btn_etc1.Size = new System.Drawing.Size(86, 58);
            this.Btn_etc1.TabIndex = 10;
            this.Btn_etc1.Text = "청포도 스파클링";
            this.Btn_etc1.UseVisualStyleBackColor = true;
            // 
            // Btn_etc5
            // 
            this.Btn_etc5.Location = new System.Drawing.Point(246, 98);
            this.Btn_etc5.Name = "Btn_etc5";
            this.Btn_etc5.Size = new System.Drawing.Size(87, 60);
            this.Btn_etc5.TabIndex = 14;
            this.Btn_etc5.Text = "블루베리 스무디";
            this.Btn_etc5.UseVisualStyleBackColor = true;
            // 
            // Btn_etc3
            // 
            this.Btn_etc3.Location = new System.Drawing.Point(132, 98);
            this.Btn_etc3.Name = "Btn_etc3";
            this.Btn_etc3.Size = new System.Drawing.Size(87, 60);
            this.Btn_etc3.TabIndex = 12;
            this.Btn_etc3.Text = "요거트스무디";
            this.Btn_etc3.UseVisualStyleBackColor = true;
            // 
            // Btn_etc2
            // 
            this.Btn_etc2.Location = new System.Drawing.Point(18, 176);
            this.Btn_etc2.Name = "Btn_etc2";
            this.Btn_etc2.Size = new System.Drawing.Size(86, 58);
            this.Btn_etc2.TabIndex = 11;
            this.Btn_etc2.Text = "복숭아 아이스티";
            this.Btn_etc2.UseVisualStyleBackColor = true;
            // 
            // Btn_afogato
            // 
            this.Btn_afogato.Location = new System.Drawing.Point(247, 23);
            this.Btn_afogato.Name = "Btn_afogato";
            this.Btn_afogato.Size = new System.Drawing.Size(86, 58);
            this.Btn_afogato.TabIndex = 9;
            this.Btn_afogato.Text = "아포가토";
            this.Btn_afogato.UseVisualStyleBackColor = true;
            // 
            // Panel_bakery
            // 
            this.Panel_bakery.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Panel_bakery.Controls.Add(this.Btn_bagel);
            this.Panel_bakery.Controls.Add(this.Btn_makarong);
            this.Panel_bakery.Controls.Add(this.Btn_honey);
            this.Panel_bakery.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Panel_bakery.Location = new System.Drawing.Point(924, 42);
            this.Panel_bakery.Name = "Panel_bakery";
            this.Panel_bakery.Size = new System.Drawing.Size(360, 324);
            this.Panel_bakery.TabIndex = 16;
            this.Panel_bakery.Visible = false;
            // 
            // Btn_bagel
            // 
            this.Btn_bagel.Location = new System.Drawing.Point(133, 23);
            this.Btn_bagel.Name = "Btn_bagel";
            this.Btn_bagel.Size = new System.Drawing.Size(86, 58);
            this.Btn_bagel.TabIndex = 7;
            this.Btn_bagel.Text = "베이글";
            this.Btn_bagel.UseVisualStyleBackColor = true;
            // 
            // Btn_makarong
            // 
            this.Btn_makarong.Location = new System.Drawing.Point(18, 23);
            this.Btn_makarong.Name = "Btn_makarong";
            this.Btn_makarong.Size = new System.Drawing.Size(86, 58);
            this.Btn_makarong.TabIndex = 8;
            this.Btn_makarong.Text = "마카롱";
            this.Btn_makarong.UseVisualStyleBackColor = true;
            // 
            // Btn_honey
            // 
            this.Btn_honey.Location = new System.Drawing.Point(247, 23);
            this.Btn_honey.Name = "Btn_honey";
            this.Btn_honey.Size = new System.Drawing.Size(86, 58);
            this.Btn_honey.TabIndex = 9;
            this.Btn_honey.Text = "허니브레드";
            this.Btn_honey.UseVisualStyleBackColor = true;
            // 
            // Btn_coffee
            // 
            this.Btn_coffee.Location = new System.Drawing.Point(414, 42);
            this.Btn_coffee.Name = "Btn_coffee";
            this.Btn_coffee.Size = new System.Drawing.Size(85, 39);
            this.Btn_coffee.TabIndex = 1;
            this.Btn_coffee.Text = "Coffee";
            this.Btn_coffee.UseVisualStyleBackColor = true;
            this.Btn_coffee.Click += new System.EventHandler(this.Btn_coffee_Click);
            // 
            // Btn_juice
            // 
            this.Btn_juice.Location = new System.Drawing.Point(414, 99);
            this.Btn_juice.Name = "Btn_juice";
            this.Btn_juice.Size = new System.Drawing.Size(85, 39);
            this.Btn_juice.TabIndex = 2;
            this.Btn_juice.Text = "쥬스/티";
            this.Btn_juice.UseVisualStyleBackColor = true;
            this.Btn_juice.Click += new System.EventHandler(this.Btn_juice_Click);
            // 
            // Btn_etc
            // 
            this.Btn_etc.Location = new System.Drawing.Point(414, 158);
            this.Btn_etc.Name = "Btn_etc";
            this.Btn_etc.Size = new System.Drawing.Size(85, 39);
            this.Btn_etc.TabIndex = 3;
            this.Btn_etc.Text = "기타음료";
            this.Btn_etc.UseVisualStyleBackColor = true;
            this.Btn_etc.Click += new System.EventHandler(this.Btn_etc_Click);
            // 
            // Btn_bakery
            // 
            this.Btn_bakery.Location = new System.Drawing.Point(414, 214);
            this.Btn_bakery.Name = "Btn_bakery";
            this.Btn_bakery.Size = new System.Drawing.Size(85, 39);
            this.Btn_bakery.TabIndex = 4;
            this.Btn_bakery.Text = "Bakery";
            this.Btn_bakery.UseVisualStyleBackColor = true;
            this.Btn_bakery.Click += new System.EventHandler(this.Btn_bakery_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(32, 384);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(155, 68);
            this.Btn_Cancel.TabIndex = 5;
            this.Btn_Cancel.Text = "주문 취소하기";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Order
            // 
            this.Btn_Order.Location = new System.Drawing.Point(240, 384);
            this.Btn_Order.Name = "Btn_Order";
            this.Btn_Order.Size = new System.Drawing.Size(155, 68);
            this.Btn_Order.TabIndex = 6;
            this.Btn_Order.Text = "주문하기";
            this.Btn_Order.UseVisualStyleBackColor = true;
            // 
            // Panel_add_c
            // 
            this.Panel_add_c.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Panel_add_c.Controls.Add(this.count);
            this.Panel_add_c.Controls.Add(this.label1);
            this.Panel_add_c.Controls.Add(this.Btn_cart);
            this.Panel_add_c.Controls.Add(this.Btn_back);
            this.Panel_add_c.Controls.Add(this.Btn_syrup3);
            this.Panel_add_c.Controls.Add(this.Btn_syrup2);
            this.Panel_add_c.Controls.Add(this.Btn_addsyrup);
            this.Panel_add_c.Controls.Add(this.Btn_hot);
            this.Panel_add_c.Controls.Add(this.Btn_ice);
            this.Panel_add_c.Controls.Add(this.Bnt_addshot);
            this.Panel_add_c.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Panel_add_c.Location = new System.Drawing.Point(523, 42);
            this.Panel_add_c.Name = "Panel_add_c";
            this.Panel_add_c.Size = new System.Drawing.Size(360, 417);
            this.Panel_add_c.TabIndex = 17;
            this.Panel_add_c.Visible = false;
            // 
            // count
            // 
            this.count.Cursor = System.Windows.Forms.Cursors.Default;
            this.count.Location = new System.Drawing.Point(246, 31);
            this.count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(87, 21);
            this.count.TabIndex = 16;
            this.count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.count.ValueChanged += new System.EventHandler(this.count_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(55, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // Btn_cart
            // 
            this.Btn_cart.Location = new System.Drawing.Point(205, 342);
            this.Btn_cart.Name = "Btn_cart";
            this.Btn_cart.Size = new System.Drawing.Size(155, 68);
            this.Btn_cart.TabIndex = 14;
            this.Btn_cart.Text = "주문담기";
            this.Btn_cart.UseVisualStyleBackColor = true;
            this.Btn_cart.Click += new System.EventHandler(this.Btn_cart_Click);
            // 
            // Btn_back
            // 
            this.Btn_back.Location = new System.Drawing.Point(0, 342);
            this.Btn_back.Name = "Btn_back";
            this.Btn_back.Size = new System.Drawing.Size(155, 68);
            this.Btn_back.TabIndex = 13;
            this.Btn_back.Text = "돌아가기";
            this.Btn_back.UseVisualStyleBackColor = true;
            this.Btn_back.Click += new System.EventHandler(this.Btn_back_Click);
            // 
            // Btn_syrup3
            // 
            this.Btn_syrup3.Location = new System.Drawing.Point(247, 153);
            this.Btn_syrup3.Name = "Btn_syrup3";
            this.Btn_syrup3.Size = new System.Drawing.Size(86, 58);
            this.Btn_syrup3.TabIndex = 12;
            this.Btn_syrup3.Text = "헤이즐넛시럽 추가";
            this.Btn_syrup3.UseVisualStyleBackColor = true;
            this.Btn_syrup3.Click += new System.EventHandler(this.Btn_coffeeOption_Click);
            // 
            // Btn_syrup2
            // 
            this.Btn_syrup2.Location = new System.Drawing.Point(133, 153);
            this.Btn_syrup2.Name = "Btn_syrup2";
            this.Btn_syrup2.Size = new System.Drawing.Size(86, 58);
            this.Btn_syrup2.TabIndex = 11;
            this.Btn_syrup2.Text = "바닐라시럽 추가";
            this.Btn_syrup2.UseVisualStyleBackColor = true;
            this.Btn_syrup2.Click += new System.EventHandler(this.Btn_coffeeOption_Click);
            // 
            // Btn_addsyrup
            // 
            this.Btn_addsyrup.Location = new System.Drawing.Point(18, 153);
            this.Btn_addsyrup.Name = "Btn_addsyrup";
            this.Btn_addsyrup.Size = new System.Drawing.Size(86, 58);
            this.Btn_addsyrup.TabIndex = 10;
            this.Btn_addsyrup.Text = "시럽 추가";
            this.Btn_addsyrup.UseVisualStyleBackColor = true;
            this.Btn_addsyrup.Click += new System.EventHandler(this.Btn_coffeeOption_Click);
            // 
            // Btn_hot
            // 
            this.Btn_hot.Location = new System.Drawing.Point(133, 75);
            this.Btn_hot.Name = "Btn_hot";
            this.Btn_hot.Size = new System.Drawing.Size(86, 58);
            this.Btn_hot.TabIndex = 7;
            this.Btn_hot.Text = "HOT";
            this.Btn_hot.UseVisualStyleBackColor = true;
            this.Btn_hot.Click += new System.EventHandler(this.Btn_IceHot_Click);
            // 
            // Btn_ice
            // 
            this.Btn_ice.Location = new System.Drawing.Point(18, 75);
            this.Btn_ice.Name = "Btn_ice";
            this.Btn_ice.Size = new System.Drawing.Size(86, 58);
            this.Btn_ice.TabIndex = 8;
            this.Btn_ice.Text = "ICE";
            this.Btn_ice.UseVisualStyleBackColor = true;
            this.Btn_ice.Click += new System.EventHandler(this.Btn_IceHot_Click);
            // 
            // Bnt_addshot
            // 
            this.Bnt_addshot.Location = new System.Drawing.Point(247, 75);
            this.Bnt_addshot.Name = "Bnt_addshot";
            this.Bnt_addshot.Size = new System.Drawing.Size(86, 58);
            this.Bnt_addshot.TabIndex = 9;
            this.Bnt_addshot.Text = "샷추가";
            this.Bnt_addshot.UseVisualStyleBackColor = true;
            this.Bnt_addshot.Click += new System.EventHandler(this.Btn_coffeeOption_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1327, 531);
            this.Controls.Add(this.Panel_bakery);
            this.Controls.Add(this.Panel_add_c);
            this.Controls.Add(this.Panel_etc);
            this.Controls.Add(this.Panel_Juice);
            this.Controls.Add(this.Btn_Order);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_bakery);
            this.Controls.Add(this.Btn_etc);
            this.Controls.Add(this.Btn_juice);
            this.Controls.Add(this.Btn_coffee);
            this.Controls.Add(this.Panel_coffee);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Panel_coffee.ResumeLayout(false);
            this.Panel_Juice.ResumeLayout(false);
            this.Panel_etc.ResumeLayout(false);
            this.Panel_bakery.ResumeLayout(false);
            this.Panel_add_c.ResumeLayout(false);
            this.Panel_add_c.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_coffee;
        private System.Windows.Forms.Button Btn_coffee;
        private System.Windows.Forms.Button Btn_juice;
        private System.Windows.Forms.Button Btn_etc;
        private System.Windows.Forms.Button Btn_bakery;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Order;
        private System.Windows.Forms.Button Btn_vanila;
        private System.Windows.Forms.Button Btn_espresso;
        private System.Windows.Forms.Button Btn_cappuccino;
        private System.Windows.Forms.Button Btn_moca;
        private System.Windows.Forms.Button Btn_latte;
        private System.Windows.Forms.Button Btn_Americano;
        private System.Windows.Forms.Button Btn_etc5;
        private System.Windows.Forms.Button Btn_etc4;
        private System.Windows.Forms.Button Btn_etc3;
        private System.Windows.Forms.Button Btn_etc2;
        private System.Windows.Forms.Button Btn_etc1;
        private System.Windows.Forms.Button Btn_afogato;
        private System.Windows.Forms.Button Btn_syrup;
        private System.Windows.Forms.Button Btn_shot;
        private System.Windows.Forms.Button Btn_juice1;
        private System.Windows.Forms.Button Btn_juice2;
        private System.Windows.Forms.Button Btn_Tea1;
        private System.Windows.Forms.Button Btn_juice3;
        private System.Windows.Forms.Button Btn_Tea3;
        private System.Windows.Forms.Button Btn_Tea2;
        private System.Windows.Forms.Button Btn_Tea4;
        private System.Windows.Forms.Button Btn_Tea5;
        private System.Windows.Forms.Panel Panel_Juice;
        private System.Windows.Forms.Panel Panel_etc;
        private System.Windows.Forms.Button Btn_etc6;
        private System.Windows.Forms.Panel Panel_bakery;
        private System.Windows.Forms.Button Btn_bagel;
        private System.Windows.Forms.Button Btn_makarong;
        private System.Windows.Forms.Button Btn_honey;
        private System.Windows.Forms.Panel Panel_add_c;
        private System.Windows.Forms.Button Btn_hot;
        private System.Windows.Forms.Button Btn_ice;
        private System.Windows.Forms.Button Bnt_addshot;
        private System.Windows.Forms.Button Btn_cart;
        private System.Windows.Forms.Button Btn_back;
        private System.Windows.Forms.Button Btn_syrup3;
        private System.Windows.Forms.Button Btn_syrup2;
        private System.Windows.Forms.Button Btn_addsyrup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown count;
    }
}

