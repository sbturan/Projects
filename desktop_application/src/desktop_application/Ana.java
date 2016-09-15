package desktop_application;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.Toolkit;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;

import javax.swing.JButton;
import javax.swing.JDesktopPane;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTabbedPane;
import javax.swing.JTextPane;
import javax.swing.SwingConstants;
import javax.swing.UIManager;

import com.mysql.jdbc.Statement;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JList;
import javax.swing.ListSelectionModel;
import javax.swing.ImageIcon;
import java.awt.Button;


public class Ana extends JFrame {
    
	static com.mysql.jdbc.Connection baglanti,baglanti2,baglanti3=null;
    static Statement statement,statement2,statement3=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";

    public  static  String[] h_tel={"","","","","","","","","","","","","","","","","","","",""};
    public  static  String[] d_tel={"","","","","","","","","","","","","","","","","","","",""};
    public  static  String[] h_values={"","","","","","","","","","","","","","","","","","","",""};
    public  static  String[] d_values={"","","","","","","","","","","","","","","","","","","",""};
    public static String[] h_konum={"","","","","","","","","","","","","","","","","","","",""};
    public static String[] d_konum={"","","","","","","","","","","","","","","","","","","",""};
    public static String user_name;
	private JDesktopPane contentPane2;
	private JLabel txtSonDurum;
	private JLabel txtHogeldiniz;
	private JLabel txtKullancAd;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try{
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement=(Statement) baglanti.createStatement();
					ResultSet result=statement.executeQuery("select p.telefon,k.enlem,k.boylam, p.ad,p.soyad,p.meslek,k.guncelleme_zamani from hizirgibiyetis.profil p,hizirgibiyetis.konum k where k.kimlik_no=p.kimlik_no order by k.guncelleme_zamani DESC LIMIT 0,20");
					int i=0;
					while(result.next()){
						String saat=result.getString("k.guncelleme_zamani");
						
						String[] saat2=saat.split(" ");
						
						String saat3=saat2[1].replace(".0", "");
						
						String sonuc;
						if(!result.getString("p.meslek").equals("HASTA")){
							sonuc=result.getString("p.ad")+" "+result.getString("p.soyad")+"/"+result.getString("p.telefon")+"/"+saat3;
						d_values[i]=sonuc;
						d_tel[i]=result.getString("p.telefon");
						d_konum[i++]=result.getString("k.enlem")+","+result.getString("k.boylam");
						}
						
						else{
							sonuc=result.getString("p.telefon")+" / "+saat3;
						 h_values[i]=sonuc;
						 h_tel[i]=result.getString("p.telefon");
						 h_konum[i++]=result.getString("k.enlem")+","+result.getString("k.boylam");
						}
						
					}
					baglanti.close(); statement.close();
					
				}catch(SQLException t){
		            JOptionPane.showMessageDialog(null, "Son durum listesi yüklenirken bir hata oluştu."+t.getMessage());
		             
		         } catch (ClassNotFoundException t) {
					// TODO Auto-generated catch block
		        	 JOptionPane.showMessageDialog(null, "Son durum listesi yüklenirken bir hata oluştu."+t.getMessage());
				}
				try {
					Ana frame = new Ana();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Ana() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
				dispose();
			}
		});
		setIconImage(Toolkit.getDefaultToolkit().getImage(Ana.class.getResource("/images/styles/standard/vehicle/car_sharing.png")));
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 584, 346);
		contentPane2 = new JDesktopPane();
		contentPane2.setBackground(UIManager.getColor("Button.background"));
		contentPane2.setBorder(null);
		setContentPane(contentPane2);
		GridBagLayout gbl_contentPane2 = new GridBagLayout();
		gbl_contentPane2.columnWidths = new int[]{116, 100, 66, 129, 115, 0, 0};
		gbl_contentPane2.rowHeights = new int[]{30, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0};
		gbl_contentPane2.columnWeights = new double[]{1.0, 1.0, 1.0, 1.0, 1.0, 0.0, Double.MIN_VALUE};
		gbl_contentPane2.rowWeights = new double[]{0.0, 0.0, 1.0, 1.0, 1.0, 0.0, 1.0, 0.0, 1.0, 0.0, Double.MIN_VALUE};
		contentPane2.setLayout(gbl_contentPane2);
		
		txtHogeldiniz = new JLabel();
		txtHogeldiniz.setHorizontalAlignment(SwingConstants.CENTER);
		txtHogeldiniz.setText("Hoşgeldiniz");
		GridBagConstraints gbc_txtHogeldiniz = new GridBagConstraints();
		gbc_txtHogeldiniz.insets = new Insets(0, 0, 5, 5);
		gbc_txtHogeldiniz.fill = GridBagConstraints.HORIZONTAL;
		gbc_txtHogeldiniz.gridx = 0;
		gbc_txtHogeldiniz.gridy = 0;
		contentPane2.add(txtHogeldiniz, gbc_txtHogeldiniz);
		
		txtKullancAd = new JLabel();
		txtKullancAd.setHorizontalAlignment(SwingConstants.CENTER);
		GridBagConstraints gbc_txtKullancAd = new GridBagConstraints();
		gbc_txtKullancAd.anchor = GridBagConstraints.WEST;
		gbc_txtKullancAd.gridwidth = 2;
		gbc_txtKullancAd.insets = new Insets(0, 0, 5, 5);
		gbc_txtKullancAd.gridx = 1;
		gbc_txtKullancAd.gridy = 0;
		txtKullancAd.setText(user_name);
		contentPane2.add(txtKullancAd, gbc_txtKullancAd);
		
		txtSonDurum = new JLabel();
		txtSonDurum.setFont(new Font("Castellar", Font.BOLD, 13));
		txtSonDurum.setHorizontalAlignment(SwingConstants.CENTER);
		txtSonDurum.setText("SON DURUM");
		GridBagConstraints gbc_txtSonDurum = new GridBagConstraints();
		gbc_txtSonDurum.gridwidth = 3;
		gbc_txtSonDurum.insets = new Insets(0, 0, 5, 5);
		gbc_txtSonDurum.fill = GridBagConstraints.HORIZONTAL;
		gbc_txtSonDurum.gridx = 1;
		gbc_txtSonDurum.gridy = 1;
		contentPane2.add(txtSonDurum, gbc_txtSonDurum);
		
		JButton btnYeniKaytGirii = new JButton("Yeni Kayıt");
		btnYeniKaytGirii.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				YeniKayit.main(null);
			}
		});
		GridBagConstraints gbc_btnYeniKaytGirii = new GridBagConstraints();
		gbc_btnYeniKaytGirii.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnYeniKaytGirii.insets = new Insets(0, 0, 5, 5);
		gbc_btnYeniKaytGirii.gridx = 0;
		gbc_btnYeniKaytGirii.gridy = 2;
		contentPane2.add(btnYeniKaytGirii, gbc_btnYeniKaytGirii);
		
		final JTabbedPane tabbedPane = new JTabbedPane(JTabbedPane.TOP);
		GridBagConstraints gbc_tabbedPane = new GridBagConstraints();
		gbc_tabbedPane.gridwidth = 3;
		gbc_tabbedPane.gridheight = 5;
		gbc_tabbedPane.insets = new Insets(0, 0, 5, 5);
		gbc_tabbedPane.fill = GridBagConstraints.BOTH;
		gbc_tabbedPane.gridx = 1;
		gbc_tabbedPane.gridy = 2;
		contentPane2.add(tabbedPane, gbc_tabbedPane);
		
		JPanel tab_hasta = new JPanel();
		tabbedPane.addTab("Hastalar", null, tab_hasta, null);
		GridBagLayout gbl_tab_hasta = new GridBagLayout();
		gbl_tab_hasta.columnWidths = new int[]{152, 178, 0};
		gbl_tab_hasta.rowHeights = new int[]{136, 0};
		gbl_tab_hasta.columnWeights = new double[]{0.0, 0.0, Double.MIN_VALUE};
		gbl_tab_hasta.rowWeights = new double[]{0.0, Double.MIN_VALUE};
		tab_hasta.setLayout(gbl_tab_hasta);
		
		JScrollPane scrollPane_1 = new JScrollPane();
		GridBagConstraints gbc_scrollPane_1 = new GridBagConstraints();
		gbc_scrollPane_1.gridwidth = 2;
		gbc_scrollPane_1.fill = GridBagConstraints.BOTH;
		gbc_scrollPane_1.gridx = 0;
		gbc_scrollPane_1.gridy = 0;
		tab_hasta.add(scrollPane_1, gbc_scrollPane_1);
		
		final JList list_hasta = new JList(h_values);
		scrollPane_1.setViewportView(list_hasta);
		
		JPanel Tab_Dr = new JPanel();
		tabbedPane.addTab("Doktorlar", null, Tab_Dr, null);
		GridBagLayout gbl_Tab_Dr = new GridBagLayout();
		gbl_Tab_Dr.columnWidths = new int[]{177, 184, 0};
		gbl_Tab_Dr.rowHeights = new int[]{18, 0, 0, 0};
		gbl_Tab_Dr.columnWeights = new double[]{0.0, 0.0, Double.MIN_VALUE};
		gbl_Tab_Dr.rowWeights = new double[]{1.0, 0.0, 0.0, Double.MIN_VALUE};
		Tab_Dr.setLayout(gbl_Tab_Dr);
		
		JScrollPane scrollPane = new JScrollPane();
		GridBagConstraints gbc_scrollPane = new GridBagConstraints();
		gbc_scrollPane.fill = GridBagConstraints.BOTH;
		gbc_scrollPane.gridheight = 3;
		gbc_scrollPane.gridwidth = 2;
		gbc_scrollPane.insets = new Insets(0, 0, 0, 5);
		gbc_scrollPane.gridx = 0;
		gbc_scrollPane.gridy = 0;
		Tab_Dr.add(scrollPane, gbc_scrollPane);
		
		final JList list_dr = new JList(d_values);
		list_dr.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		scrollPane.setViewportView(list_dr);
		
		JButton btnNewButton_3 = new JButton("Doktor Onay");
		btnNewButton_3.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				DoktorOnay.main(null);
			}
		});
		GridBagConstraints gbc_btnNewButton_3 = new GridBagConstraints();
		gbc_btnNewButton_3.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnNewButton_3.insets = new Insets(0, 0, 5, 5);
		gbc_btnNewButton_3.gridx = 4;
		gbc_btnNewButton_3.gridy = 2;
		contentPane2.add(btnNewButton_3, gbc_btnNewButton_3);
		
		JButton btnKaytSorgulama = new JButton("Kayıt Sorgulama");
		btnKaytSorgulama.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Sorgu.main(null);
			}
		});
		GridBagConstraints gbc_btnKaytSorgulama = new GridBagConstraints();
		gbc_btnKaytSorgulama.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnKaytSorgulama.insets = new Insets(0, 0, 5, 5);
		gbc_btnKaytSorgulama.gridx = 0;
		gbc_btnKaytSorgulama.gridy = 3;
		contentPane2.add(btnKaytSorgulama, gbc_btnKaytSorgulama);
		
		JButton btnNewButton_4 = new JButton("Konumlar");
		btnNewButton_4.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Konum.main(null);
			}
		});
		GridBagConstraints gbc_btnNewButton_4 = new GridBagConstraints();
		gbc_btnNewButton_4.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnNewButton_4.insets = new Insets(0, 0, 5, 5);
		gbc_btnNewButton_4.gridx = 4;
		gbc_btnNewButton_4.gridy = 3;
		contentPane2.add(btnNewButton_4, gbc_btnNewButton_4);
		
		JButton btnNewButton = new JButton("Hasta Kayıt Sil");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Hasta_Sil.main(null);
			}
		});
		GridBagConstraints gbc_btnNewButton = new GridBagConstraints();
		gbc_btnNewButton.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnNewButton.insets = new Insets(0, 0, 5, 5);
		gbc_btnNewButton.gridx = 0;
		gbc_btnNewButton.gridy = 4;
		contentPane2.add(btnNewButton, gbc_btnNewButton);
		
		JButton btnProfilEklesil = new JButton("Profil Ekle/Sil");
		btnProfilEklesil.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Profil.main(null);
			}
		});
		
		JButton btnk = new JButton("Çıkış");
		btnk.setIcon(null);
		btnk.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				dispose();
			}
		});
		GridBagConstraints gbc_btnk = new GridBagConstraints();
		gbc_btnk.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnk.insets = new Insets(0, 0, 5, 5);
		gbc_btnk.gridx = 4;
		gbc_btnk.gridy = 4;
		contentPane2.add(btnk, gbc_btnk);
		GridBagConstraints gbc_btnProfilEklesil = new GridBagConstraints();
		gbc_btnProfilEklesil.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnProfilEklesil.insets = new Insets(0, 0, 5, 5);
		gbc_btnProfilEklesil.gridx = 0;
		gbc_btnProfilEklesil.gridy = 5;
		contentPane2.add(btnProfilEklesil, gbc_btnProfilEklesil);
		
		JButton btnTwitterBilgileri = new JButton("Twitter Bilgileri");
		btnTwitterBilgileri.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				Twitter_info.main(null);
			}
		});
		GridBagConstraints gbc_btnTwitterBilgileri = new GridBagConstraints();
		gbc_btnTwitterBilgileri.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnTwitterBilgileri.insets = new Insets(0, 0, 5, 5);
		gbc_btnTwitterBilgileri.gridx = 0;
		gbc_btnTwitterBilgileri.gridy = 6;
		contentPane2.add(btnTwitterBilgileri, gbc_btnTwitterBilgileri);
		
		JButton btnGncelle = new JButton("Güncelle");
		btnGncelle.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try{
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti3=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement3=(Statement) baglanti3.createStatement();
					ResultSet result=statement3.executeQuery("select p.telefon, k.enlem,k.boylam,p.ad,p.soyad,p.meslek,k.guncelleme_zamani from hizirgibiyetis.profil p,hizirgibiyetis.konum k where k.kimlik_no=p.kimlik_no order by k.guncelleme_zamani DESC LIMIT 0,20");
					int i=0;
					while(result.next()){
						String saat=result.getString("k.guncelleme_zamani");
						String[] saat2=saat.split(" ");
						String saat3=saat2[1].replace(".0", "");
						String sonuc;
						if(!result.getString("p.meslek").equals("HASTA")){
							sonuc=result.getString("p.ad")+" "+result.getString("p.soyad")+"/"+result.getString("p.telefon")+"/"+saat3;
						 d_values[i]=sonuc;
							d_tel[i]=result.getString("p.telefon");
							d_konum[i++]=result.getString("k.enlem")+","+result.getString("k.boylam");
						
						}else{
						 sonuc=result.getString("p.telefon")+" / "+saat3;
						 h_values[i]=sonuc;
						 h_tel[i]=result.getString("p.telefon");
						 h_konum[i++]=result.getString("k.enlem")+","+result.getString("k.boylam");
						}
						
						
					}
					baglanti3.close(); statement3.close();
					
				}catch(SQLException te){
		            JOptionPane.showMessageDialog(null, "Son durum listesi güncellenirken bir hata oluştu."+te.getMessage());
		             
		         } catch (ClassNotFoundException te) {
					// TODO Auto-generated catch block
		        	 JOptionPane.showMessageDialog(null, "Son durum listesi güncellenirken bir hata oluştu."+te.getMessage());
				}
			}
		});
		GridBagConstraints gbc_btnGncelle = new GridBagConstraints();
		gbc_btnGncelle.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnGncelle.insets = new Insets(0, 0, 5, 5);
		gbc_btnGncelle.gridx = 1;
		gbc_btnGncelle.gridy = 7;
		contentPane2.add(btnGncelle, gbc_btnGncelle);
		
		JButton btnHaritadaGster = new JButton("Haritada Göster");
		btnHaritadaGster.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(tabbedPane.getSelectedIndex()==1){
					String s[]=d_konum[list_dr.getSelectedIndex()].split(",");
				    Double enlem=Double.parseDouble(s[0]);
				    Double boylam=Double.parseDouble(s[1]);
				    Map.enlem=enlem;
				    Map.boylam=boylam;
				    Map.tel=d_tel[list_dr.getSelectedIndex()]; 
				    Map.main(null); }
					if(tabbedPane.getSelectedIndex()==0){
						String s[]=h_konum[list_hasta.getSelectedIndex()].split(",");
					    Double enlem=Double.parseDouble(s[0]);
					    Double boylam=Double.parseDouble(s[1]);
					    Map.enlem=enlem;
					    Map.boylam=boylam;
					    Map.tel=h_tel[list_hasta.getSelectedIndex()]; 
					    Map.main(null); 
						
						
					}
			}
		});
		GridBagConstraints gbc_btnHaritadaGster = new GridBagConstraints();
		gbc_btnHaritadaGster.fill = GridBagConstraints.HORIZONTAL;
		gbc_btnHaritadaGster.insets = new Insets(0, 0, 5, 5);
		gbc_btnHaritadaGster.gridx = 3;
		gbc_btnHaritadaGster.gridy = 7;
		contentPane2.add(btnHaritadaGster, gbc_btnHaritadaGster);
		
		JTextPane txtpnsonDurumKutusundan = new JTextPane();
		txtpnsonDurumKutusundan.setText("*Son durum kutusundan konumları değişen hastalar,doktorlar görülebilir. Kayıt seçilip haritada göster butonuna tıklandığında seçilen kayıt haritada görüntülenir. Yenile butonu da listeyi günceller.");
		txtpnsonDurumKutusundan.setBackground(UIManager.getColor("Button.background"));
		GridBagConstraints gbc_txtpnsonDurumKutusundan = new GridBagConstraints();
		gbc_txtpnsonDurumKutusundan.gridheight = 2;
		gbc_txtpnsonDurumKutusundan.gridwidth = 6;
		gbc_txtpnsonDurumKutusundan.fill = GridBagConstraints.BOTH;
		gbc_txtpnsonDurumKutusundan.gridx = 0;
		gbc_txtpnsonDurumKutusundan.gridy = 8;
		contentPane2.add(txtpnsonDurumKutusundan, gbc_txtpnsonDurumKutusundan);
	}
}
