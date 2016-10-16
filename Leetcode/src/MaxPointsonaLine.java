import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class MaxPointsonaLine {
	public static void main(String[] args) {
		Point p1 = new Point(0, 0);
		Point p2 = new Point(0, 0);
		Point p3 = new Point(1, 1);
		System.out.println(new MaxPointsonaLine().maxPoints(new Point[] { p1, p2 }));
	}

	public class Line {
		double a;
		double b;
		HashSet<Point> points;
		boolean isy0 = false;
		int x;

		public Line(Point p1, Point p2) {
			if (p1.x == p2.x) {
				isy0 = true;
				x = p1.x;
			} else {
				a = (((double) p2.y - (double) p1.y)) / (((double) p2.x) - ((double) p1.x));
				b = (double) p1.y - (a * (double) p1.x);

				a = (double) Math.round(a * 10000d) / 10000d;
				b = (double) Math.round(b * 10000d) / 10000d;
			}
			points = new HashSet<>();
			points.add(p1);
			points.add(p2);
		}

		public Line addPoint(Point p) {
			points.add(p);
			return this;
		}

		public int getCount() {
			return points.size();
		}

		@Override
		public int hashCode() {
			// TODO Auto-generated method stub
			return 1;
		}

		@Override
		public boolean equals(Object obj) {
			Line l = (Line) obj;
			if (isy0 && l.isy0)
				return l.x == this.x;
			return l.a == this.a && l.b == this.b;

		}
	}

	public int maxPoints(Point[] points) {
		if (points.length < 2)
			return points.length;

		ArrayList<Line> list = new ArrayList<>();
		for (int i = 0; i < points.length; i++) {
			Point p1 = points[i];
			for (int j = i + 1; j < points.length; j++) {
				Point p2 = points[j];
				Line  line = new Line(p1, p2);
				
				int index = list.indexOf(line);
				if (index == -1) {
					list.add(line);
				} else {
					list.get(index).addPoint(p1).addPoint(p2);
				}

			}
		}
		int max = 0;
		for (Line l : list) {
			max = Math.max(max, l.getCount());

		}
		return max;
	}
}
