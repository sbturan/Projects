
public class Timer {
  
	 private Long startTime;
	 private Long endTime;
	 private Long res=0L;
  
	public void start(){
		this.startTime=System.currentTimeMillis();
	}
	public long end(){
		this.endTime=System.currentTimeMillis();
		long retval=res+this.endTime-this.startTime;
		res=0L;
		return retval;
	}
	public long pause(){
		this.endTime=System.currentTimeMillis();
		res=this.endTime-this.startTime;
		return res;
	}
}
