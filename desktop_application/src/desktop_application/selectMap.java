package desktop_application;

//License: GPL. Copyright 2008 by Jan Peter Stotz


import java.awt.BorderLayout;
import java.awt.Point;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Iterator;
import java.util.List;
import java.util.Random;



import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.UIManager;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import org.openstreetmap.gui.jmapviewer.Coordinate;
import org.openstreetmap.gui.jmapviewer.JMapViewer;
import org.openstreetmap.gui.jmapviewer.MapMarkerDot;
import org.openstreetmap.gui.jmapviewer.interfaces.MapMarker;




/**
 *
 * Demonstrates the usage of {@link JMapViewer}
 *
 * @author Jan Peter Stotz
 *
 */
public class selectMap extends JFrame {
   
   
   
    public selectMap() {
        super("Hasta Konumu Seçin");
        addWindowListener(new WindowAdapter() {
        	@Override
        	public void windowClosing(WindowEvent arg0) {
        	}
        });
        setSize(400, 400);
        final JMapViewer map = new JMapViewer();
        map.addMouseListener(new MouseAdapter() {
        	@Override
        	public void mouseClicked(MouseEvent e) {

        	    if(e.getClickCount() == 1 && e.getButton() == MouseEvent.BUTTON1){

        	         Point p = e.getPoint();
        	            int X = p.x+3;
        	            int Y = p.y+3;
        	            List<MapMarker> ar = map.getMapMarkerList();
        	            Iterator<MapMarker> i = ar.iterator();
        	            while (i.hasNext()) {

        	                MapMarker mapMarker = (MapMarker) i.next();

        	                Point MarkerPosition = map.getMapPosition(mapMarker.getLat(), mapMarker.getLon());
        	                if( MarkerPosition != null){

        	                    int centerX =  MarkerPosition.x;
        	                    int centerY = MarkerPosition.y;

        	                    // calculate the radius from the touch to the center of the dot
        	                    double radCircle  = Math.sqrt( (((centerX-X)*(centerX-X)) + (centerY-Y)*(centerY-Y)));

        	                    // if the radius is smaller then 23 (radius of a ball is 5), then it must be on the dot
        	                    if (radCircle < 8){
        	                    	String[] s=mapMarker.toString().split(" ");
        	                            
        	                    	
        	                    	
        	                            
										try {
											String[] adres = getAddressByGpsCoordinates( s[3],s[2]).split(" Province");
											
											YeniKayit.txtAdres.setText(adres[0]);
											String reg="\\d{5}";
											String[] tokens = adres[0].split(reg);
											int a=adres[0].indexOf(tokens[1]);
											YeniKayit.pk=YeniKayit.txtAdres.getText().substring(a-5, a);
											
											YeniKayit.en=Double.parseDouble(s[2]);
											YeniKayit.boy=Double.parseDouble(s[3]);
											dispose();
										} catch (IOException | ParseException e1) {
											// TODO Auto-generated catch block
											e1.printStackTrace();
										}
										
        	                    	
        	                    
        	                    
        	                    
        	                    }

        	                }
        	            }
        	    }

        	    else if ( e.getClickCount() == 2 && e.getButton() == MouseEvent.BUTTON1) {
        	        map.zoomIn(e.getPoint());
        	    }
        	}
        });
        getContentPane().setLayout(new BorderLayout());
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setExtendedState(JFrame.MAXIMIZED_BOTH);
        JPanel panel = new JPanel();
        getContentPane().add(panel, BorderLayout.NORTH);
        getContentPane().add(map, BorderLayout.CENTER);
        
        JButton btnk = new JButton("Çıkış");
        btnk.addActionListener(new ActionListener() {
        	public void actionPerformed(ActionEvent arg0) {
        		
        		dispose();
        		
        	}
        });
        btnk.setIcon(new ImageIcon(Map.class.getResource("/javax/swing/plaf/metal/icons/ocean/paletteClose-pressed.gif")));
        btnk.setBackground(UIManager.getColor("ToolBar.dockingForeground"));
        btnk.setBounds(1236, 42, 89, 23);
        map.add(btnk);
       
        Random rd=new Random();
        Double enlem,boylam;
        for(int i=1;i<11;i++){
        enlem=(40.975495)+rd.nextDouble()*(0.199286);
        boylam=(28.796316)+rd.nextDouble()*(0.623721);
        Coordinate g=new Coordinate(enlem,boylam);
        map.addMapMarker(new MapMarkerDot(Integer.toString(i),g));
        }
           
       Coordinate c=new Coordinate(41.106095,29.032418);
        map.setDisplayPosition(c, 11);
       map.setAutoscrolls(true);
       
      
      
        
        
    }

    
    
    

    public static void main(String[] args) {
        new selectMap().setVisible(true);
        
    }
    
   @SuppressWarnings("finally")
public static String getAddressByGpsCoordinates(String lng, String lat)
            throws MalformedURLException, IOException, org.json.simple.parser.ParseException {
         
	   URL url = new URL("http://maps.googleapis.com/maps/api/geocode/json?latlng="
               + lat + "," + lng + "&sensor=true");
       HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
       String formattedAddress = "";
       YeniKayit.url2=new URL("http://maps.google.com/maps?z=14&q="+lat+","+lng);
       try {
           InputStream in = url.openStream();
           BufferedReader reader = new BufferedReader(new InputStreamReader(in));
           String result, line = reader.readLine();
           result = line;
           while ((line = reader.readLine()) != null) {
               result += line;
           }

           JSONParser parser = new JSONParser();
           JSONObject rsp = (JSONObject) parser.parse(result);

           if (rsp.containsKey("results")) {
               JSONArray matches = (JSONArray) rsp.get("results");
               JSONObject data = (JSONObject) matches.get(0); //TODO: check if idx=0 exists
               formattedAddress = (String) data.get("formatted_address");
           }

           return "";
        }
        catch(MalformedURLException f) {      
    		System.out.println(f.getMessage());
    		
    	}   catch(IOException f) {
    		System.out.println(f.getMessage());
    		
    	}
    	catch(org.json.simple.parser.ParseException f){
    		System.out.println(f.getMessage());
    	}
        finally {
            urlConnection.disconnect();
            return formattedAddress;
        }
    }
}