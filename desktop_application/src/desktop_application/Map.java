package desktop_application;

//License: GPL. Copyright 2008 by Jan Peter Stotz


import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SwingConstants;
import javax.swing.UIManager;

import org.openstreetmap.gui.jmapviewer.Coordinate;
import org.openstreetmap.gui.jmapviewer.JMapViewer;
import org.openstreetmap.gui.jmapviewer.MapMarkerDot;

/**
 *
 * Demonstrates the usage of {@link JMapViewer}
 *
 * @author Jan Peter Stotz
 *
 */
public class Map extends JFrame {
   public static String tel;
   public static double enlem,boylam;
    static JTextField textField;
    public Map() {
        super("Yer");
        addWindowListener(new WindowAdapter() {
        	@Override
        	public void windowClosing(WindowEvent arg0) {
        	}
        });
        setSize(400, 400);
        final JMapViewer map = new JMapViewer();
        getContentPane().setLayout(new BorderLayout());
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setExtendedState(JFrame.MAXIMIZED_BOTH);
        JPanel panel = new JPanel();
        getContentPane().add(panel, BorderLayout.NORTH);
        getContentPane().add(map, BorderLayout.CENTER);
        
        JButton btnk = new JButton("Çıkış");
        btnk.addActionListener(new ActionListener() {
        	public void actionPerformed(ActionEvent arg0) {
        		enlem=0;
        		boylam=0;
        		map.removeAllMapMarkers();
        		dispose();
        		
        	}
        });
        btnk.setIcon(new ImageIcon(Map.class.getResource("/javax/swing/plaf/metal/icons/ocean/paletteClose-pressed.gif")));
        btnk.setBackground(UIManager.getColor("ToolBar.dockingForeground"));
        btnk.setBounds(1236, 42, 89, 23);
        map.add(btnk);
        
        textField = new JTextField();
        textField.setHorizontalAlignment(SwingConstants.RIGHT);
        textField.setEditable(false);
        textField.setBounds(1236, 11, 89, 20);
        map.add(textField);
        textField.setColumns(10);

  
           
       Coordinate c=new Coordinate(enlem,boylam);
        map.setDisplayPosition(c, 17);
       map.setAutoscrolls(true);
       
        
        map.addMapMarker(new MapMarkerDot("Kişi Burada",c));
    }

    
    
    

    public static void main(String[] args) {
        new Map().setVisible(true);
        textField.setText(tel);
    }
}