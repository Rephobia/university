package lab2_combo;

import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import org.sqlite.JDBC;
import java.sql.*;

public class plContr {
	
	public static ObservableList<pl> getProdList() {
	       
		ObservableList<pl> list = FXCollections.observableArrayList();
		try
			{
				DriverManager.registerDriver(new JDBC());
				Connection con=DriverManager.getConnection("jdbc:sqlite:test.db");
				Statement st = con.createStatement();
				ResultSet rs = st.executeQuery("select id, good from products");
			 		 
				while (rs.next())
					{
						pl epl=new pl(); 
						epl.setCode(rs.getInt("id"));
						epl.setName(rs.getString("good"));
						list.add(epl);	            
					}
				rs.close();
				st.close();
				con.close();
			}
		catch (SQLException e)
			{
				e.printStackTrace(); 
			}
	        return list;
	}
}
