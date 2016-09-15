package desktop_application;
import java.awt.EventQueue;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.Properties;

import javax.mail.Message;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;

import com.mysql.jdbc.Statement;



public class Sifre_Hatirla extends JFrame {
	static com.mysql.jdbc.Connection baglanti=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";
    static Statement statement=null;

	private JPanel contentPane;
	private JTextField txtEMail;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Sifre_Hatirla frame = new Sifre_Hatirla();
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
	public Sifre_Hatirla() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setTitle("Şifre Hatırlatma");
		setIconImage(Toolkit.getDefaultToolkit().getImage(Sifre_Hatirla.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblNewLabel = new JLabel("Mail Adresinizi Girin");
		lblNewLabel.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel.setBounds(124, 43, 142, 14);
		contentPane.add(lblNewLabel);
		
		txtEMail = new JTextField();
		txtEMail.setBounds(102, 64, 195, 20);
		contentPane.add(txtEMail);
		txtEMail.setColumns(10);
		
		JButton btnOnayla = new JButton("Onayla");
		btnOnayla.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Boolean control=true;
		       if(txtEMail.getText().isEmpty()){
		    	   JOptionPane.showMessageDialog(null, "Bir Mail Adresi Girin");
		    	   control=false;
		       }
		       if(control){
				try{
					
				Class.forName("com.mysql.jdbc.Driver");                 
			    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
			    statement=(Statement) baglanti.createStatement();
			    ResultSet result=statement.executeQuery("select u_password from hizirgibiyetis.admin where email='"+txtEMail.getText()+"' ");
				
			    if(result.next()){
					try{
						
						String from = "acilservis112@outlook.com";
						
						String pass = "Hizirgibiyetis14";
						
						String[] to = {txtEMail.getText() };
						
						String host = "smtp-mail.outlook.com";
						
						
						Properties props = System.getProperties();
						props.put("mail.smtp.starttls.enable", "true");
						props.put("mail.smtp.host", host);
						props.put("mail.smtp.user", from);
						props.put("mail.smtp.password", pass);
						props.put("mail.smtp.port", "587");
						props.put("mail.smtp.auth", "true");
						Session session = Session.getDefaultInstance(props, null);
						MimeMessage message = new MimeMessage(session);
						message.setFrom(new InternetAddress(from));
						InternetAddress[] toAddress = new InternetAddress[to.length];
						for (int i = 0; i < to.length; i++) {
							toAddress[i] = new InternetAddress(to[i]);
						}
			 
						for (int i = 0; i < toAddress.length; i++) {
							message.addRecipient(Message.RecipientType.TO, toAddress[i]);
						}
						message.setSubject("112 Acil Servis Şifre");
						
						message.setText("Sisteme giriş için kullanacağınız şifre="+result.getString("u_password"));
						
						Transport transport = session.getTransport("smtp");
						transport.connect(host, from, pass);
						transport.sendMessage(message, message.getAllRecipients());
						transport.close();
						
						JOptionPane.showMessageDialog(null, "Şifreniz epostaya gönderildi.");
						
					}
					catch (Exception et) {
						JOptionPane.showMessageDialog(null,"Mail Gönderirken bir hata oluştu: "+et.getMessage());
					}
					
					
					
				} else{
					JOptionPane.showMessageDialog(null,"Bu mail adresi bir kullanıcıyla eşleşmiyor!");
				}
				}
				
				
				catch(SQLException ex){
		             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
		             JOptionPane.showMessageDialog(null, "Internet bağlantısını kontrol edin.");
		         } catch (ClassNotFoundException ex) {
					// TODO Auto-generated catch block
		        	 JOptionPane.showMessageDialog(null, "Internet bağlantısını kontrol edin.");
				}}
				
				
				
			}
		});
		btnOnayla.setBounds(102, 95, 89, 23);
		contentPane.add(btnOnayla);
		
		JButton btnNewButton = new JButton("İptal");
		btnNewButton.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dispose();
			}
		});
		btnNewButton.setBounds(212, 95, 89, 23);
		contentPane.add(btnNewButton);
	}
}
