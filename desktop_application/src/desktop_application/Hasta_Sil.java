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
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SpringLayout;
import javax.swing.border.EmptyBorder;

import com.mysql.jdbc.Statement;

public class Hasta_Sil extends JFrame {
    
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";

	static com.mysql.jdbc.Connection baglanti,baglanti2=null;
    static Statement statement,statement2=null;
	private JPanel contentPane;
	private JTextField txtTC;
	private JTextField textHSTBLG;

	/**
	 * Launch the application.
	 */
	
	
	
	
	
	
	

	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Hasta_Sil frame = new Hasta_Sil();
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
	public Hasta_Sil() {
		setIconImage(Toolkit.getDefaultToolkit().getImage(Profil.class.getResource("/com/sun/java/swing/plaf/windows/icons/Computer.gif")));
		setTitle("Bekleyen Hasta Silme");
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		
		final JOptionPane optionPane = new JOptionPane(
			    "Emin Misiniz?",
			    JOptionPane.QUESTION_MESSAGE,
			    JOptionPane.YES_NO_OPTION);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		SpringLayout sl_contentPane = new SpringLayout();
		contentPane.setLayout(sl_contentPane);
		final JLabel lblMSJ = new JLabel("");
		sl_contentPane.putConstraint(SpringLayout.SOUTH, lblMSJ, -81, SpringLayout.SOUTH, contentPane);
		lblMSJ.setEnabled(false);
		final JButton btnSil = new JButton("Sil");
		btnSil.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				int cevap=optionPane.showConfirmDialog(btnSil, "Emin Misiniz?","Hasta Sil", JOptionPane.YES_NO_OPTION);
			 
				if(cevap==JOptionPane.YES_OPTION){
					try{
					Class.forName("com.mysql.jdbc.Driver");                 
				    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
				    statement2=(Statement) baglanti2.createStatement(); 
				    statement2.execute("delete from hizirgibiyetis.takip where takip_kimlik_no='"+txtTC.getText()+"'");
				    String timeStamp = new SimpleDateFormat("yyyyMMdd_HHmmss").format(Calendar.getInstance().getTime());
				    statement2.execute("insert into hizirgibiyetis.log values('"+Ana.user_name+"','silme','"+timeStamp+"')");
				    statement2.execute("delete from hizirgibiyetis.profil where kimlik_no='"+txtTC.getText()+"'");
				    
				    lblMSJ.setText("Kayıt Başarıyla Silindi");
					baglanti2.close(); statement2.close();	
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
		btnSil.setEnabled(false);
		JLabel lblSilmekIstediinizHastann = new JLabel("KAYITLARDAN SİLMEK İSTEDİĞİNİZ HASTANIN");
		sl_contentPane.putConstraint(SpringLayout.EAST, lblSilmekIstediinizHastann, -95, SpringLayout.EAST, contentPane);
		contentPane.add(lblSilmekIstediinizHastann);
		
		JLabel lblNewLabel = new JLabel("TC KİMLİK NUMARASINI GİRİN");
		sl_contentPane.putConstraint(SpringLayout.NORTH, btnSil, 121, SpringLayout.SOUTH, lblNewLabel);
		sl_contentPane.putConstraint(SpringLayout.NORTH, lblNewLabel, 59, SpringLayout.NORTH, contentPane);
		sl_contentPane.putConstraint(SpringLayout.WEST, lblNewLabel, 133, SpringLayout.WEST, contentPane);
		sl_contentPane.putConstraint(SpringLayout.EAST, lblNewLabel, -33, SpringLayout.EAST, contentPane);
		sl_contentPane.putConstraint(SpringLayout.SOUTH, lblSilmekIstediinizHastann, -6, SpringLayout.NORTH, lblNewLabel);
		contentPane.add(lblNewLabel);
		
		txtTC = new JTextField();
		sl_contentPane.putConstraint(SpringLayout.NORTH, txtTC, 18, SpringLayout.SOUTH, lblNewLabel);
		sl_contentPane.putConstraint(SpringLayout.WEST, txtTC, 0, SpringLayout.WEST, lblNewLabel);
		sl_contentPane.putConstraint(SpringLayout.EAST, txtTC, -125, SpringLayout.EAST, contentPane);
		contentPane.add(txtTC);
		txtTC.setColumns(10);
		
		JButton btnSRG = new JButton("Sorgula");
		btnSRG.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(txtTC.getText().length()!=11){
					lblMSJ.setText("Geçerli bir TC Kimlik NO giriniz..");
					lblMSJ.setEnabled(true);
					txtTC.setText("");
				}else{
					try{
						Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement=(Statement) baglanti.createStatement(); 
					    ResultSet result=statement.executeQuery("select ad,soyad,telefon from hizirgibiyetis.profil where kimlik_no='"+txtTC.getText()+"'");
					    if(result.next()){
					    textHSTBLG.setText("ad="+result.getString("ad")+" "+"Soyad="+result.getString("soyad")+" "+"Telefon="+result.getString("telefon"));
					    btnSil.setEnabled(true);
					    
					    }
					    else{  textHSTBLG.setText("Hasta Bulunamadı");
					    	
					    }
					    baglanti.close(); statement.close();
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
		sl_contentPane.putConstraint(SpringLayout.NORTH, btnSRG, 6, SpringLayout.SOUTH, txtTC);
		sl_contentPane.putConstraint(SpringLayout.EAST, btnSRG, -173, SpringLayout.EAST, contentPane);
		contentPane.add(btnSRG);
		
		JLabel lblHastaBilgiler = new JLabel("Hasta Bilgiler");
		sl_contentPane.putConstraint(SpringLayout.NORTH, lblHastaBilgiler, 5, SpringLayout.SOUTH, lblMSJ);
		sl_contentPane.putConstraint(SpringLayout.WEST, lblHastaBilgiler, 88, SpringLayout.WEST, contentPane);
		contentPane.add(lblHastaBilgiler);
		
		textHSTBLG = new JTextField();
		sl_contentPane.putConstraint(SpringLayout.WEST, btnSil, 11, SpringLayout.EAST, textHSTBLG);
		sl_contentPane.putConstraint(SpringLayout.NORTH, textHSTBLG, 195, SpringLayout.NORTH, contentPane);
		sl_contentPane.putConstraint(SpringLayout.WEST, textHSTBLG, 18, SpringLayout.WEST, contentPane);
		textHSTBLG.setEditable(false);
		sl_contentPane.putConstraint(SpringLayout.EAST, textHSTBLG, 313, SpringLayout.WEST, contentPane);
		contentPane.add(textHSTBLG);
		textHSTBLG.setColumns(10);
		contentPane.add(btnSil);
		
		
		sl_contentPane.putConstraint(SpringLayout.WEST, lblMSJ, 123, SpringLayout.WEST, contentPane);
		sl_contentPane.putConstraint(SpringLayout.EAST, lblMSJ, 0, SpringLayout.EAST, txtTC);
		contentPane.add(lblMSJ);
		
		JButton btnIptal = new JButton("İptal");
		btnIptal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dispose();
			}
		});
		sl_contentPane.putConstraint(SpringLayout.NORTH, btnIptal, 6, SpringLayout.SOUTH, btnSil);
		sl_contentPane.putConstraint(SpringLayout.WEST, btnIptal, 0, SpringLayout.WEST, btnSil);
		contentPane.add(btnIptal);
	}
}
