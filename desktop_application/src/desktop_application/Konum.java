package desktop_application;

import java.awt.EventQueue;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTable;
import javax.swing.border.BevelBorder;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;

import com.mysql.jdbc.Statement;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

public class Konum extends JFrame {

	static com.mysql.jdbc.Connection baglanti=null;
    static String url = "jdbc:mysql://94.73.145.214:3306/hizirgibiyetis?user=ekrem&password=coban&useUnicode=true&characterEncoding=utf-8";
    static Statement statement=null;
	private JPanel contentPane;
	private  JTable table;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Konum frame = new Konum();
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
	public Konum() {
		setTitle("Çağrı Konumları");
		addWindowListener(new WindowAdapter() {
			@Override
			public void windowClosing(WindowEvent arg0) {
			}
		});
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		
		final DefaultTableModel model = new DefaultTableModel(); 
		model.addColumn("Toplam");
		model.addColumn("Yuzde");
		
		
		table = new JTable(model);
		table.setBorder(new BevelBorder(BevelBorder.LOWERED, null, null, null, null));
		table.setBounds(79, 46, 275, 127);
		contentPane.add(table);
		
		model.addRow(new Object[]{"Posta Kodu", "Çağrı Sayısı"});
		table.setModel(model);
		
		
		try{
		Class.forName("com.mysql.jdbc.Driver");                 
	    baglanti=(com.mysql.jdbc.Connection) DriverManager.getConnection(url);
	    statement=(Statement) baglanti.createStatement();
	    ResultSet result=statement.executeQuery("select Posta_kodu,toplam from hizirgibiyetis.kor_kul");
	    while(result.next()){
	    	
	    	model.addRow(new Object[]{result.getString("Posta_kodu"), result.getString("toplam")});
    		table.setModel(model);
    		//baglanti6.close(); statement6.close();
	    }
	    
		}
		catch(SQLException exe){
             Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
             
         } catch (ClassNotFoundException exe) {
			// TODO Auto-generated catch block
        	 Logger.getLogger(kul_giris.class.getName()).log(Level.SEVERE, null, exe);
		}
		
	
		
		
		JButton btnIptal = new JButton("İptal");
		btnIptal.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				dispose();
			}
		});
		btnIptal.setBounds(261, 197, 89, 23);
		contentPane.add(btnIptal);
	}
	
}
