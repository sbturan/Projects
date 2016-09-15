package desktop_application;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.SystemColor;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.net.URL;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JButton;
import javax.swing.JFormattedTextField;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;
import javax.swing.text.MaskFormatter;

import twitter4j.Twitter;
import twitter4j.TwitterException;
import twitter4j.TwitterFactory;
import twitter4j.conf.ConfigurationBuilder;

import com.mysql.jdbc.Statement;


public class YeniKayit extends JFrame {
	
	static com.mysql.jdbc.Connection baglanti,baglanti2,baglanti3,baglanti4,baglanti5,baglanti6=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";
    static Statement statement,statement2,statement3,statement4,statement5,statement6=null;
   
    public static String pk;
    public static double en,boy;
    public static URL url2;
	private JPanel contentPane;
	private JFormattedTextField txtTelefonNo;
	public static JTextField txtAdres;
	private JLabel lblNewLabel;
	private JLabel lblAdres;
	private JLabel lblEmpyt_te;
	private JLabel lblEmpty_ADR;
	private JLabel lblBilgileriGsmOpertatnden;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					YeniKayit frame = new YeniKayit();
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
	public YeniKayit() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
				
			
			}
		});
		setIconImage(Toolkit.getDefaultToolkit().getImage(Profil.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setForeground(SystemColor.control);
		setTitle("Yeni Kay\u0131t");
		setBackground(SystemColor.control);
		setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBackground(SystemColor.control);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblHastaBilgileriniGirin = new JLabel("Hasta Bilgilerini Girin:");
		lblHastaBilgileriniGirin.setBounds(58, 30, 128, 14);
		contentPane.add(lblHastaBilgileriniGirin);
		MaskFormatter mask = null;
		try{
			  mask = new MaskFormatter("(###) ###-####");
			    mask.setPlaceholderCharacter('_');
		}
		catch (ParseException e) {
            e.printStackTrace();
        }
		txtTelefonNo = new JFormattedTextField(mask);
		txtTelefonNo.setBounds(58, 55, 86, 20);
		contentPane.add(txtTelefonNo);
		txtTelefonNo.setColumns(10);
		
		txtAdres = new JTextField();
		txtAdres.setEditable(false);
		txtAdres.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				lblEmpty_ADR.setText("*");
			}
		});
		txtAdres.setHorizontalAlignment(SwingConstants.LEFT);
		txtAdres.setBounds(2, 140, 432, 23);
		contentPane.add(txtAdres);
		txtAdres.setColumns(10);
		
		JButton btnKaydet = new JButton("Kaydet");
		btnKaydet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
              Boolean control=true;		
              
             
              
              if(txtTelefonNo.getText().equals("")){
            	  control=false;
            	  lblEmpyt_te.setText("Bu alan boş bırakılamaz");
              }
              if(txtAdres.getText().equals("")){
            	control=false;
            	lblEmpty_ADR.setText("Bu alan boş bırakılamaz");
              }
				if(control==true){try{
					String timeStamp = new SimpleDateFormat("yyyy-MM-dd_HH:mm:ss").format(Calendar.getInstance().getTime());
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement=(Statement) baglanti.createStatement(); 
				    statement2=(Statement)baglanti2.createStatement();
				    
				    
				    
				    statement.execute("insert into hizirgibiyetis.profil values(0,'"+txtTelefonNo.getText()+"',0,'0','0','"+txtTelefonNo.getText()+"','"+txtAdres.getText()+"','bos','HASTA','"+timeStamp+"')");  // hizirgibiyetis.admin where user_name='"+txtKullancAd.getText()+"'");
                    statement.execute("insert into hizirgibiyetis.konum values('"+txtTelefonNo.getText()+"',"+YeniKayit.en+","+YeniKayit.boy+",'"+timeStamp+"')");
				    ResultSet kimlik_no=statement.executeQuery("select kimlik_no from hizirgibiyetis.profil where meslek='DOKTOR'");
                    String no;
                    
                    while(kimlik_no.next()){
                    	
                    	no=kimlik_no.getString("kimlik_no");
                    	statement2.execute("insert into hizirgibiyetis.takip values('"+no+"','"+txtTelefonNo.getText()+"')");
                    	
                    	
                    	
                    }
                    JOptionPane.showMessageDialog(null, "Kayıt başarıyla Tamamlandı. ");
                    if(pk.length()!=0){
                    try{
                    	Class.forName("com.mysql.jdbc.Driver");                 
    			      baglanti4=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
    			      statement4=(Statement)baglanti4.createStatement();
    			      ResultSet result=statement4.executeQuery("select * from hizirgibiyetis.kor_kul where Posta_kodu='"+pk+"'");
                     if(result.next()){
                    	 Class.forName("com.mysql.jdbc.Driver");                 
       			      baglanti5=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
       			      statement5=(Statement)baglanti5.createStatement();
       			      int sayi=result.getInt("toplam");
       			      sayi++;
       			      statement5.execute("update hizirgibiyetis.kor_kul set toplam='"+Integer.toString(sayi)+"' where Posta_kodu='"+result.getString("Posta_kodu")+"'      ");
       			      
                    	 baglanti5.close(); statement5.close();
                    	 
                     }else{
                    	 Class.forName("com.mysql.jdbc.Driver");                 
          			      baglanti6=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
          			      statement6=(Statement)baglanti6.createStatement(); 
                    	 
                    	 statement6.execute("insert into hizirgibiyetis.kor_kul values('"+pk+"','1')");
                    	 statement6.close(); baglanti6.close();
                    	 
                     } 
                     
                    
                    
    			      
    			      
    			      
    			      
    			      
    			      
    			      
    			      
    			      
                    }
                    catch(SQLException ex){
			             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
			             
			         } catch (ClassNotFoundException ex) {
						// TODO Auto-generated catch block
			        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
					}
                    }
                    
                    Boolean tweet=true;
                    try{
                    	Class.forName("com.mysql.jdbc.Driver");                 
    				    baglanti3=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
    				    statement3=(Statement) baglanti3.createStatement(); 
    				    ResultSet result=statement3.executeQuery("select tweet_ayar from hizirgibiyetis.admin where user_name='"+Ana.user_name+"'");
    				    result.next();
    				    if(result.getString("tweet_ayar").equals("kapali")){
    				    	tweet=false;
    				    }else{
    				    	tweet=true;
    				    }
    				    statement3.close(); baglanti3.close();
                    }
                    catch(SQLException ex){
                    	Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
                    	} catch (ClassNotFoundException ex) {
                    	// TODO Auto-generated catch block
                    	Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
                    						}
                    if(tweet){
                    ConfigurationBuilder cb  = new ConfigurationBuilder();
                    cb.setOAuthAccessToken("2477266482-pKHAw9QqtLd2fIv3gJCiFQTC4QNZ2jT0b3Hxcqh") 
                               .setOAuthAccessTokenSecret("ky0Wu2qFu7C4EnkJxwyIvc4I1J0O4eljxXTInUpoEfyRI") 
                               .setOAuthConsumerKey("3tOD0WSmyG5pHqfZh6cQD65jt") 
                               .setOAuthConsumerSecret("4nAYgr9Qho3iHJrr43Hy8pBM3253puPRhLq54pguzVaXDeMjUJ"); 
                    
                   
                    String lastStatus="Yeni Acil Hasta: "+txtTelefonNo.getText()+"\n"+txtAdres.getText()+"\n"+url2;
                    
                    TwitterFactory tf = new TwitterFactory(cb.build());
                    Twitter twitter =tf.getInstance();
                   
    				try {
    					twitter.updateStatus(lastStatus);
    					
    				} catch (TwitterException e1) {
    					// TODO Auto-generated catch block
    					e1.printStackTrace();
    				}
                    }
                    
                    statement.close(); statement2.close(); baglanti.close(); baglanti2.close();
                    dispose();
				}
				catch(SQLException ex){
			             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
			             
			         } catch (ClassNotFoundException ex) {
						// TODO Auto-generated catch block
			        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
					}
					
					
					
				}
				
				
				
				
				
				
			}
		});
		btnKaydet.setBounds(43, 185, 89, 23);
		contentPane.add(btnKaydet);
		
		JButton btnIptal = new JButton("\u0130ptal");
		btnIptal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dispose();
			}
		});
		btnIptal.setBounds(158, 185, 89, 23);
		contentPane.add(btnIptal);
		
		lblNewLabel = new JLabel("Telefon");
		lblNewLabel.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel.setBounds(2, 58, 46, 14);
		contentPane.add(lblNewLabel);
		
		lblAdres = new JLabel("Adres");
		lblAdres.setHorizontalAlignment(SwingConstants.CENTER);
		lblAdres.setBounds(2, 83, 46, 14);
		contentPane.add(lblAdres);
		
		lblEmpyt_te = new JLabel("*");
		lblEmpyt_te.setForeground(new Color(255, 0, 0));
		lblEmpyt_te.setBounds(158, 55, 165, 14);
		contentPane.add(lblEmpyt_te);
		
		lblEmpty_ADR = new JLabel("*");
		lblEmpty_ADR.setForeground(Color.RED);
		lblEmpty_ADR.setBounds(283, 163, 129, 14);
		contentPane.add(lblEmpty_ADR);
		
		JButton btnAdresTespit = new JButton("Bigileri Çek");
		btnAdresTespit.setBounds(248, 74, 128, 23);
		contentPane.add(btnAdresTespit);
		
		JLabel lblbuButonaTklandnda = new JLabel("*Bu butona tıklandığında \r\nhasta ");
		lblbuButonaTklandnda.setVerticalAlignment(SwingConstants.TOP);
		lblbuButonaTklandnda.setHorizontalAlignment(SwingConstants.LEFT);
		lblbuButonaTklandnda.setBounds(248, 105, 186, 20);
		contentPane.add(lblbuButonaTklandnda);
		
		lblBilgileriGsmOpertatnden = new JLabel("bilgileri GSM opertaötünden çekilir.");
		lblBilgileriGsmOpertatnden.setVerticalAlignment(SwingConstants.TOP);
		lblBilgileriGsmOpertatnden.setHorizontalAlignment(SwingConstants.LEFT);
		lblBilgileriGsmOpertatnden.setBounds(218, 118, 216, 23);
		contentPane.add(lblBilgileriGsmOpertatnden);
		
		JButton btnHaritadanSe = new JButton("Haritadan Seç");
		btnHaritadanSe.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				selectMap.main(null);
			}
		});
		btnHaritadanSe.setBounds(55, 86, 131, 23);
		contentPane.add(btnHaritadanSe);
	}
}
