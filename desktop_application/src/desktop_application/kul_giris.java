package desktop_application;

import java.awt.Color;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.SystemColor;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.UIManager;
import javax.swing.border.EmptyBorder;

public class kul_giris extends JFrame {
	
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";

	static com.mysql.jdbc.Connection baglanti,baglanti2=null;
    static Statement statement,statement2=null;

	private JPanel contentPane;
	private JTextField txtKullancAd;
	private JButton btnifremiUnuttum;
	private JLabel lblNewLabel;
	private JPasswordField txtifre;
	private JLabel lblKullancAd;
	private JLabel lblifre;

	/**
	 * Launch the application.
	 */
	
	
	
	
	
	

	public static void main(String[] args) {
		
		
		
		
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					kul_giris frame = new kul_giris();
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
	public kul_giris() {
		setResizable(false);
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setIconImage(Toolkit.getDefaultToolkit().getImage(Profil.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setTitle("Kullan\u0131c\u0131 Giri\u015Fi");
		setBackground(SystemColor.control);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblAcilHastaTakip = new JLabel("Acil Hasta Takip Sistemi \n "+"Kullanıcı Girişi");
		lblAcilHastaTakip.setBounds(75, 22, 241, 18);
		lblAcilHastaTakip.setForeground(Color.BLUE);
		lblAcilHastaTakip.setFont(new Font("Buxton Sketch", Font.BOLD, 14));
		lblAcilHastaTakip.setHorizontalAlignment(SwingConstants.CENTER);
		lblAcilHastaTakip.setVerticalAlignment(SwingConstants.BOTTOM);
		contentPane.add(lblAcilHastaTakip);
		
		lblNewLabel = new JLabel("");
		lblNewLabel.setBounds(5, 51, 260, 0);
		lblNewLabel.setForeground(UIManager.getColor("ToolBar.dockingForeground"));
		lblNewLabel.setEnabled(false);
		lblNewLabel.setHorizontalAlignment(SwingConstants.CENTER);
		contentPane.add(lblNewLabel);
		
		txtKullancAd = new JTextField();
		txtKullancAd.setBounds(125, 67, 140, 20);
		
		
		lblKullancAd = new JLabel("Kullanıcı Adı");
		lblKullancAd.setBounds(15, 70, 77, 14);
		contentPane.add(lblKullancAd);
		txtKullancAd.setHorizontalAlignment(SwingConstants.CENTER);
		contentPane.add(txtKullancAd);
		txtKullancAd.setColumns(10);
		
		JButton btnGiri = new JButton("Giri\u015F");
		btnGiri.setBounds(135, 124, 97, 23);
		btnGiri.addActionListener(new ActionListener() {
			@SuppressWarnings("deprecation")
			public void actionPerformed(ActionEvent arg0) {
				if(txtKullancAd.getText().equals("")||txtifre.getText().equals(""))
				{ lblNewLabel.enable();
				   lblNewLabel.setText("Kullanıcı adı/şifre boş bırakılamaz");
				}else{
				
				try {
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement=(Statement) baglanti.createStatement(); 
				    
				    ResultSet result=statement.executeQuery("select u_password from hizirgibiyetis.admin where user_name='"+txtKullancAd.getText()+"'");
				    
					if((!result.next())||!result.getString(1).equals(txtifre.getText())){
						lblNewLabel.setText("Kullanıcı adı/şifre hatalı");  txtKullancAd.setText(""); txtifre.setText("");
					} else{
						Ana.user_name=txtKullancAd.getText();
						Ana.main(null);
						Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement2=(Statement) baglanti2.createStatement(); 
					    String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(Calendar.getInstance().getTime());
					    statement2.execute("insert into hizirgibiyetis.log values('"+txtKullancAd.getText()+"','giris','"+timeStamp+"')");  
					    baglanti2.close(); statement2.close();
        					dispose();
						baglanti.close();
						statement.close();
						
					}
					
				}  
						catch(SQLException ex){
				             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
				             JOptionPane.showMessageDialog(null, "Internet bağlantısını kontrol edin. communication link failure");
				         } catch (ClassNotFoundException ex) {
							// TODO Auto-generated catch block
				        	 JOptionPane.showMessageDialog(null, "Internet bağlantısını kontrol edin. communication link failure");
						}
						
				
				}
				
			}
		});
		
		lblifre = new JLabel("Şifre");
		lblifre.setBounds(25, 96, 51, 14);
		contentPane.add(lblifre);
		
		txtifre = new JPasswordField();
		txtifre.setBounds(125, 93, 140, 20);
		txtifre.setHorizontalAlignment(SwingConstants.CENTER);
		contentPane.add(txtifre);
		contentPane.add(btnGiri);
		
		btnifremiUnuttum = new JButton("\u015Eifremi Unuttum");
		btnifremiUnuttum.setBounds(102, 148, 163, 23);
		btnifremiUnuttum.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				Sifre_Hatirla.main(null);
			}
		});
		contentPane.add(btnifremiUnuttum);
	}

}
