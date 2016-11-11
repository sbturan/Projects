import java.io.File;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.google.gson.Gson;

@WebServlet("/getAppList")
public class GetWarList extends HttpServlet {
	private static final long serialVersionUID = -5850368209768736949L;

	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse response)
			throws javax.servlet.ServletException, java.io.IOException {
		List<String> appList = getAppList();
		response.setContentType("application/json");
		response.setCharacterEncoding("utf-8");
		PrintWriter out = response.getWriter();

		Gson gson=new Gson();
		String list= gson.toJson(appList);
		out.println(list);

	};

	public List<String> getAppList() {

		File f = new File(System.getProperty( "catalina.base" ).concat("/webapps"));
		List<String> result = new ArrayList<String>();
		for (File fi : f.listFiles()) {
			if (fi.getName().endsWith(".war") && !fi.getName().equals("MainPage.war")) {
				result.add(fi.getName().replaceAll(".war", ""));
			}
		}

		return result;
	}
}
