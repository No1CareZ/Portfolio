import java.beans.XMLDecoder;
import java.beans.XMLEncoder;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;

public class WorkWithXML {
    public static void CodeZoo(Zoo Park, String calling) {
        try {
            FileOutputStream f = new FileOutputStream(calling);
            XMLEncoder encod = new XMLEncoder(f);
            encod.writeObject(Park);
            encod.close();
            f.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (java.io.IOException ioe) {
            ioe.printStackTrace();
        }
    }

    public static void CodeCage(Cage Cell, String calling) {
        try {
            FileOutputStream f = new FileOutputStream(calling);
            XMLEncoder encod = new XMLEncoder(f);
            encod.writeObject(Cell);
            encod.close();
            f.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (java.io.IOException ioe) {
            ioe.printStackTrace();
        }
    }

    public static void CodeAnim(Animal tem, String calling) {
        try {
            FileOutputStream f = new FileOutputStream(calling);
            XMLEncoder encod = new XMLEncoder(f);
            encod.writeObject(tem);
            encod.close();
            f.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (java.io.IOException ioe) {
            ioe.printStackTrace();
        }
    }

    public static void CodeTest(Test ok, String calling) {
        try {
            FileOutputStream f = new FileOutputStream(calling);
            XMLEncoder encod = new XMLEncoder(f);
            encod.writeObject(ok);
            encod.close();
            f.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (java.io.IOException ioe) {
            ioe.printStackTrace();
        }
    }

    public static Class deserializeFromXML() {
        FileInputStream f;
        {
            try {
                f = new FileInputStream("C://files_stockpile//savexml.xml");
                XMLDecoder decod = new XMLDecoder(f);
                Class decoded = (Class) decod.readObject();
                decod.close();
                f.close();
                return decoded;
            } catch (FileNotFoundException e) {
                throw new RuntimeException(e);
            } catch (java.io.IOException ioe) {
                ioe.printStackTrace();
            }
        }
        return null;
    }
}
