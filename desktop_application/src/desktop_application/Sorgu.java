package desktop_application;

import java.awt.EventQueue;
import java.awt.SystemColor;
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
import java.util.Vector;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.AbstractAction;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JRadioButton;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;

import com.mysql.jdbc.Statement;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class Sorgu extends JFrame {
 
	static com.mysql.jdbc.Connection baglanti,baglanti2,baglanti3=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";
    static Statement statement,statement2,statement3=null;
	private JPanel contentPane;
	private JTextField txtTckimlikNo;
	private JTextArea textSNC;
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Sorgu frame = new Sorgu();
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
	public Sorgu() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setIconImage(Toolkit.getDefaultToolkit().getImage(Profil.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setTitle("Sorgulama");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 536, 338);
		contentPane = new JPanel();
		contentPane.setBackground(SystemColor.control);
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		final JButton d_button = new JButton("Sorgula");
		
		final JButton btnSorgula = new JButton("Sorgula");
		final JRadioButton rdbtnHastaBilgilerineGre = new JRadioButton("Hasta Bilgilerine G\u00F6re");
		Vector comboBoxItems=new Vector();
		final DefaultComboBoxModel model = new DefaultComboBoxModel(comboBoxItems);
		final JComboBox comboBox = new JComboBox(model);
		comboBox.setEnabled(false);
		comboBox.setBounds(317, 76, 95, 20);
		contentPane.add(comboBox);
		
		final JRadioButton rdbtnDoktorBilgilerineGre = new JRadioButton("Doktor Bilgilerine G\u00F6re");
		rdbtnDoktorBilgilerineGre.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				txtTckimlikNo.setEditable(false);
				btnSorgula.setEnabled(false);
				rdbtnHastaBilgilerineGre.setSelected(false);
				d_button.setEnabled(true);
				comboBox.setEnabled(true);
				try{
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement2=(Statement) baglanti2.createStatement(); 
				    
				    ResultSet result=statement2.executeQuery("select ad,soyad from hizirgibiyetis.profil where meslek='DOKTOR'");
				    while(result.next()){
				    model.addElement(result.getString("ad")+" "+result.getString("soyad"));
				    }
				    baglanti2.close(); statement2.close();
				}
				catch(SQLException exe){
		             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
		             
		         } catch (ClassNotFoundException exe) {
					// TODO Auto-generated catch block
		        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
				}
			}
		});
		rdbtnDoktorBilgilerineGre.setBounds(290, 35, 191, 23);
		contentPane.add(rdbtnDoktorBilgilerineGre);
		
		
		rdbtnHastaBilgilerineGre.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent arg0) {
				d_button.setEnabled(false);
				comboBox.setEnabled(false);
				txtTckimlikNo.setEditable(true);
				rdbtnDoktorBilgilerineGre.setSelected(false);
				btnSorgula.setEnabled(true);
				
				
			}
		});
		d_button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				String selected=comboBox.getSelectedItem().toString();
				String[] adSoyad=selected.split(" ");
				try{
					
				Class.forName("com.mysql.jdbc.Driver");                 
			    baglanti3=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
			    statement3=(Statement) baglanti3.createStatement(); 
			    
			    ResultSet sonuc=statement3.executeQuery("select p.kimlik_no,p.ad,p.soyad,p.telefon,p.sifre,p.kayit_tarihi,p.email from hizirgibiyetis.profil p where p.ad='"+adSoyad[0]+"' and p.soyad='"+adSoyad[1]+"'");
			    
			    if(!sonuc.next()){textSNC.setText("KAYIT BULUNAMADI");} else{
			    	sonuc.beforeFirst();
			    	
			    	
			    while(sonuc.next()){
			    	java.sql.Timestamp tarih = sonuc.getTimestamp("p.kayit_tarihi");
			    	
			    	textSNC.setText(sonuc.getString("p.ad")+" "+sonuc.getString("p.soyad")+"\nKimlik NO="+sonuc.getString("p.kimlik_no")+"\n"+"Telefon= "+sonuc.getString("p.telefon")+"\n"+"Email= "+sonuc.getString("p.email")+"\n"+"Şifre="+sonuc.getString("p.sifre")+"\n"+"tarih="+tarih+"\n");
			    }
			    baglanti3.close(); statement3.close();}
			    
					
				}
				catch(SQLException exep){
		             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exep);
		             
		         } catch (ClassNotFoundException exep) {
					// TODO Auto-generated catch block
		        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exep);
				}
				
				
			}
		});
		
		rdbtnHastaBilgilerineGre.setSelected(true);
		rdbtnHastaBilgilerineGre.setBounds(33, 35, 166, 23);
		contentPane.add(rdbtnHastaBilgilerineGre);
		
		
		
		txtTckimlikNo = new JTextField();
		txtTckimlikNo.setBounds(58, 76, 102, 20);
		contentPane.add(txtTckimlikNo);
		txtTckimlikNo.setColumns(10);
		
		
		JLabel lblSeiniz = new JLabel("Se\u00E7iniz");
		lblSeiniz.setBounds(261, 68, 46, 37);
		contentPane.add(lblSeiniz);
		
		
		btnSorgula.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				if(txtTckimlikNo.getText().length()!=10){
					JOptionPane.showMessageDialog(null, "Geçerli bir TC NO giriniz..");
					txtTckimlikNo.setText("");
					
					
				}else{
					try{ 
						Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement=(Statement) baglanti.createStatement(); 
					    
					    ResultSet result=statement.executeQuery("select * from hizirgibiyetis.profil where kimlik_no='"+txtTckimlikNo.getText()+"'and meslek='HASTA'");
					    if(!result.next()){textSNC.setText("KAYIT BULUNAMADI");} else{
					    	result.beforeFirst();
					    while(result.next()){
					    	java.sql.Timestamp tarih = result.getTimestamp("kayit_tarihi");
					    	
					    	textSNC.setText(" Tel NO="+result.getString("kimlik_no")+"\n"+" Adres="+result.getString("adres")+"\n"+" Kayıt tarihi="+tarih+"\n");
					    	
					    }
					    }baglanti.close();
					    statement.close();
					    
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
		btnSorgula.setBounds(71, 107, 89, 23);
		contentPane.add(btnSorgula);
		
		
		d_button.setEnabled(false);
		d_button.setBounds(323, 107, 89, 23);
		contentPane.add(d_button);
		
		JScrollPane scrollPane = new JScrollPane();
		scrollPane.setBounds(10, 172, 500, 116);
		contentPane.add(scrollPane);
		
		textSNC = new JTextArea();
		scrollPane.setViewportView(textSNC);
		textSNC.setColumns(10);
		
		JLabel lblTcNo = new JLabel("Tel. NO");
		lblTcNo.setBounds(10, 79, 46, 14);
		contentPane.add(lblTcNo);
		
		JButton btnk = new JButton("İptal");
		btnk.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				model.removeAllElements();
				dispose();
				
			}
		});
		btnk.setBounds(323, 139, 89, 23);
		contentPane.add(btnk);
		
		
	}
	private class SwingAction extends AbstractAction {
		public SwingAction() {
			putValue(NAME, "SwingAction");
			putValue(SHORT_DESCRIPTION, "Some short description");
		}
		public void actionPerformed(ActionEvent e) {
		}
	}
}
