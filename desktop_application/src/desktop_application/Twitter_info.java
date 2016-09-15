package desktop_application;
import java.awt.EventQueue;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.naming.ldap.Rdn;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;

import com.mysql.jdbc.Statement;


public class Twitter_info extends JFrame {
	
	static com.mysql.jdbc.Connection baglanti,baglanti2=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";
    static Statement statement,statement2=null; 

    final static JRadioButton rdbtnAk = new JRadioButton("Açık");
	final static JRadioButton rdbtnKapal = new JRadioButton("Kapalı");
	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		try{
			Class.forName("com.mysql.jdbc.Driver");         
			baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
			statement=(Statement) baglanti.createStatement();
			
			
			ResultSet result=statement.executeQuery("select tweet_ayar from hizirgibiyetis.admin where user_name='"+Ana.user_name+"'");
             result.next();
             if(result.getString("tweet_ayar").equals("kapali")){
            	 rdbtnAk.setSelected(false);
            	 rdbtnKapal.setSelected(true);
            	 
             }else{
            	 rdbtnAk.setSelected(true);
            	 rdbtnKapal.setSelected(false);
             }
			
		}
		catch(SQLException sqs){
			Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, sqs);
			} catch (ClassNotFoundException sqs) {
			// TODO Auto-generated catch block
			Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, sqs);
								}
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				
				
				
				try {
					Twitter_info frame = new Twitter_info();
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
	public Twitter_info() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setIconImage(Toolkit.getDefaultToolkit().getImage(Twitter_info.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblNewLabel = new JLabel("Twitter Kullanıcı Adı: AcilHasta112");
		lblNewLabel.setHorizontalAlignment(SwingConstants.LEFT);
		lblNewLabel.setBounds(27, 35, 269, 38);
		contentPane.add(lblNewLabel);
		
		JLabel lblNewLabel_1 = new JLabel("Twitter Şifre: Hizirgibiyetis14");
		lblNewLabel_1.setBounds(27, 67, 163, 14);
		contentPane.add(lblNewLabel_1);
		
		JLabel lblNewLabel_2 = new JLabel("Mail Adresi: acilservis112@outlook.com");
		lblNewLabel_2.setBounds(27, 84, 281, 14);
		contentPane.add(lblNewLabel_2);
		
		JLabel lblNewLabel_3 = new JLabel("Mail Şifre: Hizirgibiyetis14");
		lblNewLabel_3.setBounds(27, 104, 188, 14);
		contentPane.add(lblNewLabel_3);
		
		final JLabel lblNewLabel_4 = new JLabel("*Yeni hasta kaydı yaptığınızda belirtilen hesaptan bir tweet atılır");
		lblNewLabel_4.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_4.setBounds(0, 236, 434, 14);
		contentPane.add(lblNewLabel_4);
		
		JLabel lblNewLabel_5 = new JLabel("Tweet gönderme ayarı:");
		lblNewLabel_5.setBounds(27, 129, 130, 14);
		contentPane.add(lblNewLabel_5);
		
		
		rdbtnAk.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				
				rdbtnKapal.setSelected(false);
			}
		});
		rdbtnAk.setBounds(194, 125, 50, 23);
		contentPane.add(rdbtnAk);
		
		
		rdbtnKapal.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent arg0) {
				rdbtnAk.setSelected(false);
				
			}
		});
		rdbtnKapal.setBounds(263, 125, 109, 23);
		contentPane.add(rdbtnKapal);
		
		JButton btnKaydet = new JButton("Kaydet");
		btnKaydet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				
				try{
					Class.forName("com.mysql.jdbc.Driver");         
					baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					statement2=(Statement) baglanti2.createStatement(); 
				if(rdbtnKapal.isSelected()){
					statement2.execute("update hizirgibiyetis.admin set tweet_ayar='kapali' where user_name='"+Ana.user_name+"'");
					JOptionPane.showMessageDialog(null,"Tweet ayarınız -kapalı- olarak kaydedildi");
				}
				if(rdbtnAk.isSelected()){
					statement2.execute("update hizirgibiyetis.admin set tweet_ayar='acik' where user_name='"+Ana.user_name+"'");
					JOptionPane.showMessageDialog(null,"Tweet ayarınız -açık- olarak kaydedildi");
				}
				}
				catch(SQLException ex){
					Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
					} catch (ClassNotFoundException ex) {
					// TODO Auto-generated catch block
					Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
										}
			}
		});
		btnKaydet.setBounds(148, 171, 89, 23);
		contentPane.add(btnKaydet);
		
		JButton btnIptal = new JButton("İptal");
		btnIptal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dispose();
			}
		});
		btnIptal.setBounds(268, 171, 89, 23);
		contentPane.add(btnIptal);
	}
}
