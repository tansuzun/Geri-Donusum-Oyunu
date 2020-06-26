/****************************************************************************
**					     SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					    2019-2020 BAHAR DÖNEMİ
**	                         Proje Ödevi
**				ÖĞRENCİ ADI............: Tansu Uzun
**				ÖĞRENCİ NUMARASI.......: B191210073
**              DERSİN ALINDIĞI GRUP...: B
****************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Deployment.Application;

namespace NDPProje
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Dolu hacimi belirlemek için değişkenler oluşturdum.
        int OrganikPuan = 0;
        int KagitPuan = 0;
        int CamPuan = 0;
        int MetalPuan = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Başlangıçta tüm butonları etkisizleştiriyor.
            btnCam.Enabled = false;
            btnCBosalt.Enabled = false;
            btnOBosalt.Enabled = false;
            btnMBosalt.Enabled = false;
            btnKBosalt.Enabled = false;
            btnOrganik.Enabled = false;
            btnKagit.Enabled = false;
            btnMetal.Enabled = false;

        }

        //Fotoğrafları dizide tuttum.
        ArrayList resim = new ArrayList();
        private void btnYeniOyun_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
            progressBar4.Value = 0;

            //Puanı 0'dan başlatmak için
            label3.Text = 0.ToString();

            //btnYeniOyun.Enabled = false;
            timer1.Enabled = true;
            btnCam.Enabled = true;
            btnOrganik.Enabled = true;
            btnKagit.Enabled = true;
            btnMetal.Enabled = true;

            //Süreyi 60'dan başlatmak için
            label4.Text = 60.ToString();

            OrganikAtıkKutusu org = new OrganikAtıkKutusu();
            KagitKutusu kagit = new KagitKutusu();
            CamKutusu cam = new CamKutusu();
            MetalKutusu metal = new MetalKutusu();
            Domates domates = new Domates();
            Salatalik salatalik = new Salatalik();
            Bardak bardak = new Bardak();
            CamSise camsise = new CamSise();
            Gazete gazete = new Gazete();
            Dergi dergi = new Dergi();
            KolaKutusu kola = new KolaKutusu();
            SalcaKutusu salca = new SalcaKutusu();
        

            Random rnd = new Random();

            //Yorumlar fotoğrafların dizinin kaçıncı elemanı olduğunu gösteriyor.
            /*0*/ resim.Add("bardak.png");
            /*1*/ resim.Add("camsise.png");
            /*2*/ resim.Add("gazete.png");
            /*3*/ resim.Add("dergi.png");
            /*4*/ resim.Add("domates.png");
            /*5*/ resim.Add("salatalik.png");
            /*6*/ resim.Add("kolasisesi.png");
            /*7*/ resim.Add("salcakutusu.png");
            pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];


        }


        private void button3_Click(object sender, EventArgs e)
        {
            OrganikAtıkKutusu org = new OrganikAtıkKutusu();
            org.Kapasite = 700;
            progressBar1.Maximum = org.Kapasite;

            //Picturebox'daki fotoğraf domates ise işlem yapıyor.(Bütün kutular ve atıklar için aynı koşulları kullandım.)
            if (pictureBox1.ImageLocation == (string)resim[4])
            {
                Domates domates = new Domates();
                listBox1.Items.Add("Domates" + "("+ domates.Hacim + ")");
                OrganikPuan += domates.Hacim;
                label3.Text = (Convert.ToInt32(label3.Text) + domates.Hacim).ToString();

                //Eklenecek atığın hacmi kapasiteden küçükse kutuya ekliyor.
                if ((progressBar1.Value + domates.Hacim) < org.Kapasite)
                {
                    progressBar1.Value += domates.Hacim;
                }
                //Atığın hacmi kapasiteden büyükse butonu etkisizleştiriyor ve boşalt butonunu aktifleştiriyor.
                else
                {
                    btnOrganik.Enabled = false;
                }
                
                Random rnd = new Random();
                pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];
             }

            //Picturebox'daki fotoğraf salatalik ise işlem yapıyor.
            if (pictureBox1.ImageLocation == (string)resim[5])
                {
                    Salatalik salatalik = new Salatalik();
                    listBox1.Items.Add("Salatalık" + "(" + salatalik.Hacim + ")");
                    OrganikPuan += salatalik.Hacim;
              
                    label3.Text = (Convert.ToInt32(label3.Text) + salatalik.Hacim).ToString();
               
                    if ((progressBar1.Value+ salatalik.Hacim) < org.Kapasite)
                    {
                            progressBar1.Value += salatalik.Hacim;
                    }

                    else
                    {
                        // btnOBosalt.Enabled = true;
                        btnOrganik.Enabled = false;
                    }
              
                    Random rnd = new Random();
                    pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];
                }

                org.DoluHacim = OrganikPuan;
                //Kutunun doluluk oranı 75 in üzerindeyse boşalt butonunu aktifleştiriyor.
                if (org.Bosalt())
                {
                    btnOBosalt.Enabled = true;
                }

        }

        private void btnKagit_Click(object sender, EventArgs e)
        {
            KagitKutusu kagit = new KagitKutusu();
            kagit.Kapasite = 1200;
            progressBar2.Maximum = kagit.Kapasite;
           
                if (pictureBox1.ImageLocation == (string)resim[3])
                {
                    Dergi dergi = new Dergi();
                    listBox2.Items.Add("Dergi" + "(" + dergi.Hacim + ")");
                    KagitPuan += dergi.Hacim;
                    label3.Text = (Convert.ToInt32(label3.Text) + dergi.Hacim).ToString();
               
                    if ((progressBar2.Value + dergi.Hacim) < kagit.Kapasite)
                    {
                        progressBar2.Value += dergi.Hacim;
                    }

                    else
                    {
                        btnKagit.Enabled = false;
                    }

                        Random rnd = new Random();
                        pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];

                    }


                    if (pictureBox1.ImageLocation == (string)resim[2])
                    {
                        Gazete gazete = new Gazete();
                        listBox2.Items.Add("Gazete" + "(" + gazete.Hacim + ")");
                        KagitPuan += gazete.Hacim;
                        label3.Text = (Convert.ToInt32(label3.Text) + gazete.Hacim).ToString();
                
                    if ((progressBar2.Value + gazete.Hacim) < kagit.Kapasite)
                    {
                        progressBar2.Value += gazete.Hacim;
                    }
                    else
                    {
                        btnKagit.Enabled = false;
                    }

                    Random rnd = new Random();
                    pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];

                }

                kagit.DoluHacim = KagitPuan;
                if (kagit.Bosalt())
                {
                    btnKBosalt.Enabled = true;
                }

        }



        private void btnCam_Click(object sender, EventArgs e)
        {
            CamKutusu cam = new CamKutusu();
            cam.Kapasite = 2200;
            progressBar3.Maximum = cam.Kapasite;

           if (pictureBox1.ImageLocation == (string)resim[0])
           {
                Bardak bardak = new Bardak();
                listBox3.Items.Add("Bardak" + "(" + bardak.Hacim + ")");
                CamPuan += bardak.Hacim;
                label3.Text = (Convert.ToInt32(label3.Text) + bardak.Hacim).ToString();

               
                if ((progressBar3.Value + bardak.Hacim) < cam.Kapasite)
                {
                   progressBar3.Value += bardak.Hacim;
                }
                   
                else
                {
                   btnCam.Enabled = false;
                }
                   

                Random rnd = new Random();
                pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];

                }

                if (pictureBox1.ImageLocation == (string)resim[1])
                {
                    CamSise camsise = new CamSise();
                    listBox3.Items.Add("Cam Şişe" + "(" + camsise.Hacim + ")");
                    CamPuan+= camsise.Hacim;
                    label3.Text = (Convert.ToInt32(label3.Text) + camsise.Hacim).ToString();

                    if ((progressBar3.Value + camsise.Hacim) < cam.Kapasite)
                    {
                        progressBar3.Value += camsise.Hacim;
                    }
                   
                    else
                    {
                        btnCam.Enabled = false;
                    }

                    Random rnd = new Random();
                    pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];

                }
                cam.DoluHacim = CamPuan;

                if (cam.Bosalt())
                {
                    btnCBosalt.Enabled = true;
                }


        }

        private void btnMetal_Click(object sender, EventArgs e)
        {
            MetalKutusu metal = new MetalKutusu();
            metal.Kapasite = 2300;
            progressBar4.Maximum = metal.Kapasite;

            if (pictureBox1.ImageLocation == (string)resim[6])
            {
                KolaKutusu kola = new KolaKutusu();
                listBox4.Items.Add("Kola Kutusu" + "(" + kola.Hacim + ")");
                MetalPuan += kola.Hacim;
                label3.Text = (Convert.ToInt32(label3.Text) + kola.Hacim).ToString();


                if ((progressBar4.Value + kola.Hacim) < metal.Kapasite)
                {
                    progressBar4.Value += kola.Hacim;
                }
               
                if((progressBar4.Value + kola.Hacim) >= metal.Kapasite)
                {
                    btnMetal.Enabled = false;
                }
                Random rnd = new Random();
                pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];

            }

                if (pictureBox1.ImageLocation == (string)resim[7])
                {
                SalcaKutusu salca = new SalcaKutusu();
                listBox4.Items.Add("Salça Kutusu" + "(" + salca.Hacim + ")");
                    MetalPuan += salca.Hacim;
                    label3.Text = (Convert.ToInt32(label3.Text) + salca.Hacim).ToString();


                    if ((progressBar4.Value + salca.Hacim) < metal.Kapasite)
                    {
                        progressBar4.Value += salca.Hacim;
                    }
                   
                    if((progressBar4.Value + salca.Hacim) >= metal.Kapasite)
                    {
                        btnMetal.Enabled = false;

                    }
                    Random rnd = new Random();
                    pictureBox1.ImageLocation = (string)resim[rnd.Next(0, 8)];

                }

            metal.DoluHacim = MetalPuan;
            if (metal.Bosalt())
            {
                btnMBosalt.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sure = Convert.ToInt32(label4.Text);
            sure--;
            label4.Text = sure.ToString();

            if(sure==0)
            {
                timer1.Enabled = false;
                btnCam.Enabled = false;
                btnCBosalt.Enabled = false;
                btnOBosalt.Enabled = false;
                btnMBosalt.Enabled = false;
                btnKBosalt.Enabled = false;
                btnOrganik.Enabled = false;
                btnKagit.Enabled = false;
                btnMetal.Enabled = false;
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                progressBar3.Value = 0;
                progressBar4.Value = 0;
            }
            
        }

        private void btnOBosalt_Click(object sender, EventArgs e)
        {
            btnOrganik.Enabled = true;
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            //Süreye 3 saniye ekliyor.
            label4.Text = (Convert.ToInt32(label4.Text) + 3).ToString();
            btnOBosalt.Enabled = false;
            OrganikPuan = 0;
        }

        private void btnKBosalt_Click(object sender, EventArgs e)
        {
            KagitKutusu kagit = new KagitKutusu();
            btnKagit.Enabled = true;
            progressBar2.Value = 0;
            listBox2.Items.Clear();
            label4.Text = (Convert.ToInt32(label4.Text) + 3).ToString();
            //Boşaltma puanını ekliyor.
            label3.Text = (Convert.ToInt32(label3.Text) + kagit.bosaltmaPuani).ToString();
            btnKBosalt.Enabled = false;
            KagitPuan = 0;
        }

        private void btnCBosalt_Click(object sender, EventArgs e)
        {
            CamKutusu cam = new CamKutusu();
            btnCam.Enabled = true;
            progressBar3.Value = 0;
            listBox3.Items.Clear();
            label4.Text = (Convert.ToInt32(label4.Text) + 3).ToString();
            label3.Text = (Convert.ToInt32(label3.Text) + cam.bosaltmaPuani).ToString();
            btnCBosalt.Enabled = false;
            CamPuan = 0;

        }

        private void btnMBosalt_Click(object sender, EventArgs e)
        {
            MetalKutusu metal = new MetalKutusu();
            btnMetal.Enabled = true;
            progressBar4.Value = 0;
            listBox4.Items.Clear();
            label4.Text = (Convert.ToInt32(label4.Text) + 3).ToString();
            label3.Text = (Convert.ToInt32(label3.Text) + metal.bosaltmaPuani).ToString();
            btnMBosalt.Enabled = false;
            MetalPuan = 0;
        }

        //Yanlışlıkla tıkladım
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }



    public interface IAtik
    {
        int Hacim { get; }
        System.Drawing.Image Image { get; }

    }

    public interface IDolabilen
    {
        int Kapasite { get; set; }
        int DoluHacim { get; }
        int DolulukOrani { get; }
    }

    public interface IAtikKutusu : IDolabilen
    {
        /// <summary>
        /// Atık kutusu boşaltıldığında oyun puanına kaç puan ekleneceğini döndürür.
        /// </summary>
        int bosaltmaPuani { get; }

        /// <summary>
        /// Atık kutusunda gönderilen atığı alacak kadar boş yer varsa atığı kutuya ekler.
        /// </summary>
        /// <param name="atik">Eklenecek Atık</param>
        /// <returns>Atığın kutuya eklenip eklenmediğini döndürür.</returns>
        bool Ekle(IAtik atik);

        /// <summary>
        /// Atık kutusunun doluluk oranı %75'in üstündeyse atık kutusunu boşaltır.
        /// </summary>
        /// <returns>Atık kutusunun boşaltılıp boşaltılmadığını döndürür.</returns>
        bool Bosalt();
    }


}
