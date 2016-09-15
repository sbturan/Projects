package desktop_application;

import java.awt.EventQueue;
import java.awt.Font;
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
import javax.swing.JTabbedPane;
import javax.swing.JTable;
import javax.swing.JTextArea;
import javax.swing.ListSelectionModel;
import javax.swing.UIManager;
import javax.swing.border.EmptyBorder;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;
import javax.swing.table.DefaultTableModel;

import com.mysql.jdbc.Statement;

public class DoktorOnay extends JFrame {
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";

	static com.mysql.jdbc.Connection baglanti,baglanti2,baglanti3,baglanti4,baglanti5,baglanti6,baglanti7=null;
    static Statement statement,statement2,statement3,statement4,statement5,statement6,statement7=null;
	private JPanel contentPane;
	private JTextArea textField;
	private JTable table;

	/**
	 * Launch the application.
	 */
	

	/**
	 * Create the frame.
	 */
	
	
	

	public DoktorOnay() {
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setTitle("Doktor Onay ");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBackground(UIManager.getColor("Button.background"));
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		final JTabbedPane pane_Info = new JTabbedPane(JTabbedPane.TOP);
		pane_Info.setBounds(10, 11, 414, 188);
		contentPane.add(pane_Info);
		
		JPanel Info = new JPanel();
		pane_Info.addTab("Bilgi", null, Info, null);
		Info.setLayout(null);
		
		textField = new JTextArea();
		textField.setEditable(false);
		textField.setBackground(UIManager.getColor("Button.background"));
		textField.setFont(new Font("Calibri", Font.PLAIN, 14));
		textField.setText("-Bu ekrandan telefonla aradığınız doktorun hastayı kabul edip etmediği \r\nbilgisini, 'Onay' sekmesine geçerek işaretleyebilirsiniz.\r\n-'Yüzdeler' sekmesinden ise doktorların kabul yüzdelerini görebilirsiniz.");
		textField.setBounds(0, 5, 409, 197);
		Info.add(textField);
		textField.setColumns(10);
		
		final JPanel Onay = new JPanel();
		
		pane_Info.addTab("Onay", null, Onay, null);
		Onay.setLayout(null);
		
		JLabel lblDoktorSein = new JLabel("Doktor Seçin");
		lblDoktorSein.setBounds(33, 11, 106, 14);
		Onay.add(lblDoktorSein);
		
		Vector comboBoxItems=new Vector();
		final DefaultComboBoxModel model = new DefaultComboBoxModel(comboBoxItems);
		final JComboBox comboBox = new JComboBox(model);
		comboBox.setBounds(24, 36, 115, 20);
		Onay.add(comboBox);
		
		JButton btnOnay = new JButton("Onay");
		btnOnay.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				
				int dialogResult = JOptionPane.showConfirmDialog (null, "Doktora onay vermek istediğinizden emin misiniz? ","Uyarı",JOptionPane.YES_NO_OPTION);
				if(dialogResult == JOptionPane.YES_OPTION){
					String selected=comboBox.getSelectedItem().toString();
					String[] adSoyad=selected.split(" ");
					try{
						Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti2=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement2=(Statement) baglanti2.createStatement(); 
					    ResultSet result=statement2.executeQuery("select p.kimlik_no,d.onay,d.toplam from hizirgibiyetis.doktor_onay d,hizirgibiyetis.profil p where p.kimlik_no=d.kimlik_no and p.ad='"+adSoyad[0]+"' and p.soyad='"+adSoyad[1]+"'");
					    result.next();
					    int onay=result.getInt("d.onay");
					    int toplam=result.getInt("d.toplam");
					    String tc=result.getString("p.kimlik_no");
					    onay++; toplam++;
					    Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti3=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement3=(Statement) baglanti3.createStatement();
					    statement3.execute("update hizirgibiyetis.doktor_onay set onay='"+Integer.toString(onay)+"', toplam='"+Integer.toString(toplam)+"'where kimlik_no='"+tc+"'");
					    Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti7=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement7=(Statement) baglanti7.createStatement();
					    statement7.execute("delete from hizirgibiyetis.takip where kimlik_no='"+tc+"'");
					    baglanti2.close(); statement2.close();  
					    baglanti3.close(); statement3.close();
					    baglanti7.close(); statement7.close();
					    JOptionPane.showMessageDialog(null, "Kayıt tamamlandı");
					}
					catch(SQLException exe){
			             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
			             
			         } catch (ClassNotFoundException exe) {
						// TODO Auto-generated catch block
			        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
					}
					
					
				}
			}
		});
		btnOnay.setBounds(10, 69, 65, 23);
		Onay.add(btnOnay);
		
		JButton btnRet = new JButton("Ret");
		btnRet.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int dialogResult = JOptionPane.showConfirmDialog (null, "Doktora Ret puanı vermek istediğinizden emin misiniz? ","Uyarı",JOptionPane.YES_NO_OPTION);
				if(dialogResult == JOptionPane.YES_OPTION){
					String selected=comboBox.getSelectedItem().toString();
					String[] adSoyad=selected.split(" ");
					try{
						Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti4=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement4=(Statement) baglanti4.createStatement(); 
					    ResultSet result=statement4.executeQuery("select p.kimlik_no,d.onay,d.toplam from hizirgibiyetis.doktor_onay d,hizirgibiyetis.profil p where p.kimlik_no=d.kimlik_no and p.ad='"+adSoyad[0]+"' and p.soyad='"+adSoyad[1]+"'");
					    result.next();
					    int onay=result.getInt("d.onay");
					    int toplam=result.getInt("d.toplam");
					    String tc=result.getString("p.kimlik_no");
					     toplam++;
					    Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti5=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement5=(Statement) baglanti5.createStatement();
					    statement5.execute("update hizirgibiyetis.doktor_onay set onay='"+Integer.toString(onay)+"', toplam='"+Integer.toString(toplam)+"'where kimlik_no='"+tc+"'");
					    
					    baglanti4.close(); statement4.close(); 
					    baglanti5.close(); statement5.close();
					    JOptionPane.showMessageDialog(null, "Kayıt tamamlandı");
					}
					catch(SQLException exe){
			             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
			             
			         } catch (ClassNotFoundException exe) {
						// TODO Auto-generated catch block
			        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
					}
					
					
				}
				
				
			}
		});
		btnRet.setBounds(90, 69, 65, 23);
		Onay.add(btnRet);
		
		final JPanel Yuzde = new JPanel();
		pane_Info.addTab("Yüzdeler", null, Yuzde, null);
		Yuzde.setLayout(null);
		
		final DefaultTableModel Tmodel = new DefaultTableModel(); 
		Tmodel.addColumn("Toplam");
		Tmodel.addColumn("Yuzde");
		Tmodel.addColumn("Soyadı");
		Tmodel.addColumn("Adı");
		
		
		table = new JTable(Tmodel);
		table.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		table.setModel(new DefaultTableModel(
			new Object[][] {
				{},
			},
			new String[] {
			}
		));
		table.setBounds(10, 0, 312, 175);
		Yuzde.add(table);
		
		JButton btnIptal = new JButton("İptal");
		btnIptal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				table.removeAll();
				comboBox.removeAll();
				dispose();
			}
		});
		btnIptal.setBounds(311, 210, 89, 23);
		contentPane.add(btnIptal);
		pane_Info.addChangeListener(new ChangeListener() {
		        public void stateChanged(ChangeEvent e) {
		           
                      		       	
		        	if(pane_Info.getSelectedIndex()==1){
		        		
		        	int rows =Tmodel.getRowCount();
		        	for(int i = rows - 1; i >=0; i--)
		        	{
		        	   Tmodel.removeRow(i); 
		        	   
		        	}
		        		
		        		try{
							Class.forName("com.mysql.jdbc.Driver");                 
						    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
						    statement=(Statement) baglanti.createStatement(); 
						    
						    ResultSet result=statement.executeQuery("select ad,soyad from hizirgibiyetis.profil where meslek='DOKTOR'");
						    while(result.next()){
						    model.addElement(result.getString("ad")+" "+result.getString("soyad"));
						    }
						    baglanti.close(); statement.close();
						}
						catch(SQLException exe){
				             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
				             
				         } catch (ClassNotFoundException exe) {
							// TODO Auto-generated catch block
				        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
						}
		        		
		        		
		        	}
		        	
		        	if(pane_Info.getSelectedIndex()==2){
		        		model.removeAllElements();
		        		
		        		Tmodel.addRow(new Object[]{"Adı", "Soyadı","Yuzde","Toplam"});
		        		table.setModel(Tmodel);
		        		try{
		        		Class.forName("com.mysql.jdbc.Driver");                 
					    baglanti6=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
					    statement6=(Statement) baglanti6.createStatement();
					    ResultSet result=statement6.executeQuery("select p.ad,p.soyad,o.onay,o.toplam from hizirgibiyetis.doktor_onay o,hizirgibiyetis.profil p where o.kimlik_no=p.kimlik_no and p.meslek='DOKTOR'");
					    while(result.next()){
					    	Double yuzde=Double.parseDouble(result.getString("o.onay"))/Double.parseDouble(result.getString("o.toplam"))*100;
					    	Tmodel.addRow(new Object[]{result.getString("p.ad"), result.getString("p.soyad"),Double.toString(yuzde),result.getString("o.toplam")});
			        		table.setModel(Tmodel);
			        		//baglanti6.close(); statement6.close();
					    }
					    
		        		}
		        		catch(SQLException exe){
				             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
				             
				         } catch (ClassNotFoundException exe) {
							// TODO Auto-generated catch block
				        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
						}
		        		
		        		
		        		
		        		
		        	}
		        	if(pane_Info.getSelectedIndex()==0){
		        		model.removeAllElements();
		        		int rows =Tmodel.getRowCount();
			        	for(int i = rows - 1; i >=0; i--)
			        	{
			        	   Tmodel.removeRow(i); 
			        	   
			        	}
		        	}
		        	
		        	
		        	
		        	
		        }
		    });
	}
	public static void main(String[] args) {
		
		
		
		
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					DoktorOnay frame = new DoktorOnay();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}
}
