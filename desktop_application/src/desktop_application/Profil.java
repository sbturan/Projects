package desktop_application;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.DefaultComboBoxModel;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;

import com.mysql.jdbc.Statement;


public class Profil extends JFrame {
	
	static com.mysql.jdbc.Connection baglanti,baglanti2,baglanti3,baglanti4,baglanti5,baglanti6,baglanti7=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";
    static Statement statement,statement2,statement3,statement4,statement5,statement6,statement7=null;

	private JPanel contentPane;
	private JTextField text_Ad;
	private JPasswordField passwordField;
	private JPasswordField passwordField_tekrar;
	private JTextField txt_e_posta;
	private JTextField txt_sil_sifre;
	private JPasswordField password_deg_mevcut;
	private JPasswordField password_deg_yeni;
	private JPasswordField password_deg_tekrar;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Profil frame = new Profil();
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
	public Profil() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setIconImage(Toolkit.getDefaultToolkit().getImage(Profil.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setTitle("Profil Yönetimi");
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		final JPanel panel_ekle = new JPanel();
		panel_ekle.setVisible(false);
		panel_ekle.setBounds(34, 38, 128, 201);
		contentPane.add(panel_ekle);
		panel_ekle.setLayout(null);
		
		JLabel lblNewLabel = new JLabel("Kullanıcı Adı");
		lblNewLabel.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel.setBounds(0, 5, 128, 14);
		panel_ekle.add(lblNewLabel);
		
		text_Ad = new JTextField();
		text_Ad.setBounds(21, 24, 86, 20);
		panel_ekle.add(text_Ad);
		text_Ad.setColumns(10);
		
		JLabel lblNewLabel_1 = new JLabel("Şifre");
		lblNewLabel_1.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_1.setBounds(34, 45, 59, 14);
		panel_ekle.add(lblNewLabel_1);
		
		passwordField = new JPasswordField();
		passwordField.setBounds(21, 62, 86, 20);
		panel_ekle.add(passwordField);
		
		JLabel lblNewLabel_2 = new JLabel("Şifre Tekrar");
		lblNewLabel_2.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_2.setBounds(0, 87, 128, 14);
		panel_ekle.add(lblNewLabel_2);
		
		passwordField_tekrar = new JPasswordField();
		passwordField_tekrar.setBounds(21, 105, 86, 20);
		panel_ekle.add(passwordField_tekrar);
		
		JLabel lblNewLabel_3 = new JLabel("New label");
		lblNewLabel_3.setBounds(47, 128, -2, 8);
		panel_ekle.add(lblNewLabel_3);
		
		JLabel lblNewLabel_4 = new JLabel("E-Mail");
		lblNewLabel_4.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_4.setBounds(34, 128, 59, 22);
		panel_ekle.add(lblNewLabel_4);
		
		txt_e_posta = new JTextField();
		txt_e_posta.setBounds(21, 147, 86, 20);
		panel_ekle.add(txt_e_posta);
		txt_e_posta.setColumns(10);
		
		JButton btn_profil_kaydet = new JButton("Kaydet");
		btn_profil_kaydet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Boolean control=true;
				try{
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement2=(Statement) baglanti2.createStatement(); 
				}
				catch(SQLException exe){
		             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
		             
		         } catch (ClassNotFoundException exe) {
					// TODO Auto-generated catch block
		        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
				}
				if(text_Ad.getText().length()==0||txt_e_posta.getText().length()==0||passwordField.getText().length()==0
						||passwordField_tekrar.getText().length()==0){
					control=false;
					JOptionPane.showMessageDialog(null, "Bütün alanların doldurulması zorunludur!");
					passwordField.setText("");
					passwordField_tekrar.setText("");
					
					
				}
				if(control==true&&text_Ad.getText().length()>15){
					control=false;
					JOptionPane.showMessageDialog(null, "Kullanıcı adı en fazla 15 karakter olabiir");
				}
				if(control==true&&!passwordField.getText().equals(passwordField_tekrar.getText())){
					control=false;
					JOptionPane.showMessageDialog(null, "Girdiğiniz şifreler eşleşmiyor!");
					passwordField.setText("");
					passwordField_tekrar.setText("");
				}
				String email=txt_e_posta.getText();
				if (control==true&&!email.matches("(?simx)\\b[A-Z0-9._%+-]+" +"@[A-Z0-9.-]+\\.[A-Z]{2,4}\\b")){
					control=false;
					JOptionPane.showMessageDialog(null, "Geçerli bir e posta giriniz");
				}
				try{
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement2=(Statement) baglanti2.createStatement(); 
				    ResultSet result=statement2.executeQuery("select * from hizirgibiyetis.admin where email='"+txt_e_posta.getText()+"'");
				    if(control==true&&result.next()){
				    	control=false;
				    	txt_e_posta.setText("");
				    	JOptionPane.showMessageDialog(null, "Girdiğiniz e posta başka bir kullanıcı tarafından kullanılıyor!");
				    }
				    statement2.close();
				    baglanti2.close();
				}
				catch(SQLException ex){
		             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
		             
		         } catch (ClassNotFoundException ex) {
					// TODO Auto-generated catch block
		        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
				}
				if(control){
					try{
						Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement=(Statement) baglanti.createStatement(); 
					    statement.execute("insert into hizirgibiyetis.admin values('"+text_Ad.getText()+"','"+passwordField.getText()+"','"+txt_e_posta.getText()+"','acik')");
					    JOptionPane.showMessageDialog(null, "Kullanıcı başarıyla kaydedildi");
					    txt_e_posta.setText("");text_Ad.setText("");passwordField.setText("");passwordField_tekrar.setText("");
					    baglanti.close();
					    statement.close();
					    
					    
					    
					}catch(SQLException ex){
			             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
			             
			         } catch (ClassNotFoundException ex) {
						// TODO Auto-generated catch block
			        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
					}
					
					
				}
			}
		});
		btn_profil_kaydet.setBounds(18, 178, 89, 23);
		panel_ekle.add(btn_profil_kaydet);
		final JPanel panel_sil = new JPanel();
		panel_sil.setVisible(false);
		panel_sil.setBounds(172, 38, 114, 201);
		contentPane.add(panel_sil);
		panel_sil.setLayout(null);
		
		Vector comboBoxItems=new Vector();
		final DefaultComboBoxModel model = new DefaultComboBoxModel(comboBoxItems);
		final JComboBox comboBox = new JComboBox(model);
		comboBox.setBounds(0, 27, 114, 20);
		panel_sil.add(comboBox);
		
		JLabel lblSilinecekProfili = new JLabel("Silinecek Profili");
		lblSilinecekProfili.setHorizontalAlignment(SwingConstants.CENTER);
		lblSilinecekProfili.setBounds(0, 11, 114, 14);
		panel_sil.add(lblSilinecekProfili);
		
		JLabel lblNewLabel_5 = new JLabel("Profil Şifresi");
		lblNewLabel_5.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_5.setBounds(0, 58, 114, 14);
		panel_sil.add(lblNewLabel_5);
		
		txt_sil_sifre = new JTextField();
		txt_sil_sifre.setBounds(10, 76, 86, 20);
		panel_sil.add(txt_sil_sifre);
		txt_sil_sifre.setColumns(10);
		
		JButton btn_sil = new JButton("Sil");
		btn_sil.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Boolean control=true;
				if(comboBox.getSelectedItem()==null){
					JOptionPane.showMessageDialog(null, "Bir Kullanıcı Seçin");
					txt_sil_sifre.setText("");
					control=false;
				}
				try{
					Class.forName("com.mysql.jdbc.Driver");         
					baglanti4=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					statement4=(Statement) baglanti4.createStatement(); 
					ResultSet result=statement4.executeQuery("select u_password from hizirgibiyetis.admin where user_name='"+comboBox.getSelectedItem().toString()+"'");
					result.next();
					if(control==true&&!result.getString("u_password").equals(txt_sil_sifre.getText())){ 
						control=false;
						JOptionPane.showMessageDialog(null, "Girdiğiniz şifre yanlış!");
						
					} baglanti4.close(); statement4.close();
				}
				catch(SQLException b){
					Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, b);
								             
								         } catch (ClassNotFoundException b) {
											// TODO Auto-generated catch block
					Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, b);
										}
				
				if(control){
					try{
						Class.forName("com.mysql.jdbc.Driver");         
						baglanti5=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
						statement5=(Statement) baglanti5.createStatement(); 
						statement5.execute("delete from hizirgibiyetis.admin where user_name='"+comboBox.getSelectedItem().toString()+"'");
						model.removeElement(comboBox.getSelectedItem());
						JOptionPane.showMessageDialog(null, "Kayıt başarıyla silindi");
						txt_sil_sifre.setText("");
						statement5.close(); baglanti5.close();

					}
					catch(SQLException c){
						Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, c);
						} catch (ClassNotFoundException c) {
						// TODO Auto-generated catch block
						Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, c);
											}
					
					
				}
				
				
			}
		});
		btn_sil.setBounds(0, 107, 114, 23);
		panel_sil.add(btn_sil);
		
		final JPanel panel_sifre = new JPanel();
		panel_sifre.setVisible(false);
		panel_sifre.setBounds(296, 38, 123, 183);
		contentPane.add(panel_sifre);
		panel_sifre.setLayout(null);
		
		JLabel lblNewLabel_6 = new JLabel("Mevcut Şifre");
		lblNewLabel_6.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_6.setBounds(0, 11, 123, 14);
		panel_sifre.add(lblNewLabel_6);
		
		password_deg_mevcut = new JPasswordField();
		password_deg_mevcut.setBounds(22, 36, 76, 20);
		panel_sifre.add(password_deg_mevcut);
		
		JLabel lblNewLabel_7 = new JLabel("Yeni Şifre");
		lblNewLabel_7.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_7.setBounds(0, 56, 123, 20);
		panel_sifre.add(lblNewLabel_7);
		
		password_deg_yeni = new JPasswordField();
		password_deg_yeni.setBounds(22, 80, 76, 20);
		panel_sifre.add(password_deg_yeni);
		
		JLabel lblNewLabel_8 = new JLabel("Yeni Şifre Tekrar");
		lblNewLabel_8.setHorizontalAlignment(SwingConstants.CENTER);
		lblNewLabel_8.setBounds(0, 101, 123, 20);
		panel_sifre.add(lblNewLabel_8);
		
		password_deg_tekrar = new JPasswordField();
		password_deg_tekrar.setBounds(22, 124, 76, 20);
		panel_sifre.add(password_deg_tekrar);
		
		JButton btn_degistir = new JButton("Değiştir");
		btn_degistir.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				Boolean control=true;
				if(password_deg_mevcut.getText().equals("")||password_deg_tekrar.getText().equals("")||password_deg_yeni.getText().equals(""))
				{
					control=false;
					JOptionPane.showMessageDialog(null,"Tüm Alanları Doldurunuz");
					password_deg_mevcut.setText("");
					password_deg_tekrar.setText("");
					password_deg_yeni.setText("");
					
				}
				
		
			
			try{
				Class.forName("com.mysql.jdbc.Driver");         
				baglanti6=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				statement6=(Statement) baglanti6.createStatement(); 
                
				ResultSet result=statement6.executeQuery("select u_password from hizirgibiyetis.admin where user_name='"+Ana.user_name+"' ");
					result.next();
					if(control==true&&!result.getString("u_password").equals(password_deg_mevcut.getText())){
						JOptionPane.showMessageDialog(null, "Mevcut şifrenizi hatalı girdiniz..");
						password_deg_mevcut.setText("");
						password_deg_tekrar.setText("");
						password_deg_yeni.setText("");
						control=false;
					}
				
					statement6.close(); baglanti6.close();
					
			}
			catch(SQLException f){
				
				JOptionPane.showMessageDialog(null,"Bir Hata Oluştu "+f.getMessage()+" İnternet Bağlantılarını kontrol edin.." );
				} 
			
			catch (ClassNotFoundException f) {
				// TODO Auto-generated catch block
					JOptionPane.showMessageDialog(null,"Bir Hata Oluştu "+f.getMessage()+" İnternet Bağlantılarını kontrol edin.." );
									}
			
			if(control==true&&!password_deg_tekrar.getText().equals(password_deg_yeni.getText())){
				control=false;
				JOptionPane.showMessageDialog(null, "Yeni Şifreler Eşleşmiyor..");
				password_deg_yeni.setText("");
				password_deg_tekrar.setText("");
				
			}
			
			
			if(control){
				try{
					Class.forName("com.mysql.jdbc.Driver");         
					baglanti7=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					statement7=(Statement) baglanti7.createStatement(); 
					
					statement7.execute("update hizirgibiyetis.admin set u_password='"+password_deg_yeni.getText()+"'where user_name='"+Ana.user_name+"'");
					
					JOptionPane.showMessageDialog(null,"Şifreniz Başarıyla Güncellendi");
					statement7.close(); baglanti7.close();
					password_deg_mevcut.setText("");
					password_deg_tekrar.setText("");
					password_deg_yeni.setText("");
					
					
					
				}
				catch(SQLException f){
					
					JOptionPane.showMessageDialog(null,"Bir Hata Oluştu "+f.getMessage()+" İnternet Bağlantılarını kontrol edin.." );
					} 
				
				catch (ClassNotFoundException f) {
					// TODO Auto-generated catch block
						JOptionPane.showMessageDialog(null,"Bir Hata Oluştu "+f.getMessage()+" İnternet Bağlantılarını kontrol edin.." );
				
				
			}
			
				
				
		}
			
			
			
			}});
		
		btn_degistir.setBounds(0, 155, 123, 23);
		panel_sifre.add(btn_degistir);
		
		JButton btn_ekle = new JButton("Profil Ekle");
		btn_ekle.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				panel_ekle.setVisible(true);
				panel_sifre.setVisible(false);
				panel_sil.setVisible(false);
			}
		});
		btn_ekle.setBounds(35, 15, 128, 23);
		contentPane.add(btn_ekle);
		
		JButton btn_Sil = new JButton("Profil Sil");
		btn_Sil.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				panel_ekle.setVisible(false);
				panel_sifre.setVisible(false);
				panel_sil.setVisible(true);
				model.removeAllElements();
				try{
				Class.forName("com.mysql.jdbc.Driver");                 
			    baglanti3=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
			    statement3=(Statement) baglanti3.createStatement(); 
			    ResultSet result=statement3.executeQuery("select user_name from hizirgibiyetis.admin");
			    while(result.next()){
			    model.addElement(result.getString("user_name"));
			    	
			    }
			    statement3.close();baglanti3.close();
			    
					}
				
			        catch(SQLException ex){
					Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
		             
		         } catch (ClassNotFoundException ex) {
					// TODO Auto-generated catch block
                    Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, ex);
				}
			}});
		btn_Sil.setBounds(184, 15, 89, 23);
		contentPane.add(btn_Sil);
		
		JButton btn_Sifre = new JButton("Şifre Değiştir");
		btn_Sifre.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				panel_ekle.setVisible(false);
				panel_sifre.setVisible(true);
				panel_sil.setVisible(false);
				
			}
		});
		btn_Sifre.setBounds(296, 15, 123, 23);
		contentPane.add(btn_Sifre);
		
		JLabel lbl_bilgi = new JLabel("Bu ekranda kullandığınız uygulama için geçerli olacak profil düzenlemelerini yapabilirsiniz");
		lbl_bilgi.setFont(new Font("Tahoma", Font.PLAIN, 9));
		lbl_bilgi.setHorizontalAlignment(SwingConstants.LEFT);
		lbl_bilgi.setBounds(10, 250, 424, 21);
		contentPane.add(lbl_bilgi);
		
		JButton btnIptal = new JButton("İptal");
		btnIptal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				dispose();
			}
		});
		btnIptal.setBounds(330, 226, 89, 23);
		contentPane.add(btnIptal);
	}
}
