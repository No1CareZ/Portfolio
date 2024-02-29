import javax.swing.*;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.io.ObjectInputStream;

public class Panels {
    public static void main(String[] args) {

        Zoo NPark = new Zoo();

        //=================================================//
        JFrame f = new JFrame("Zoo"); // Main panel
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JTabbedPane tp = new JTabbedPane(); // Place for sub panels
        JButton b_sfom = new JButton("SformirovatOpisanie");

        JPanel p1 = new JPanel(); // Cage info - panel
        JTextField te_p1 = new JTextField(); // Cage info - text sub_panel
        DefaultListModel<Cage> l_p1 = new DefaultListModel<>(); // List info - list sub_panel
        te_p1.setPreferredSize(new Dimension(300,300));

        JList<Cage> f_l_p1 = new JList<>(l_p1);
        f_l_p1.setPreferredSize(new Dimension(250,300));

        p1.add(f_l_p1, BorderLayout.LINE_START);
        p1.add(te_p1, BorderLayout.LINE_END); // Gluing

        JPanel p2 = new JPanel(); // Animals - panel
        JTextArea te_p2 = new JTextArea(); // Animals - text sub_panel

        DefaultListModel<Animal> l_p2 = new DefaultListModel<>();
        JList<Animal> f_l_p2 = new JList<>(l_p2);


        te_p2.setPreferredSize(new Dimension(300,300));
        f_l_p2.setPreferredSize(new Dimension(250, 300));

        p2.add(f_l_p2, BorderLayout.LINE_START);
        p2.add(te_p2, BorderLayout.LINE_END);

        b_sfom.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String mes;
                try{
                    mes = f_l_p2.getSelectedValue().sformirovatOpisanie();
                    JOptionPane.showMessageDialog(f,mes);
                } catch (NazvanieException ex) {
                    throw new RuntimeException(ex);
                } catch (Exception ex) {
                    throw new RuntimeException(ex);
                }

            }
        });

        f_l_p1.addListSelectionListener(new ListSelectionListener() {
            @Override
            public void valueChanged(ListSelectionEvent e) {
                String Discribe, Spisoc="";
                Cage ca = f_l_p1.getSelectedValue();
                Discribe = "Number:= " + ca.getNumber() + "; Size:= " + ca.getSize() + "; Capasity:= " + ca.getСapacity() + " Current:= " + ca.getCurrent() +"; ";
                te_p1.setText(Discribe);
                l_p2.clear();
                for (Animal a: ca.getPassengers()){
                    l_p2.addElement(a);
                    try {
                        Spisoc = Spisoc.concat( "====================\n" + a.sformirovatOpisanie() + "\n");
                    } catch (NazvanieException ex) {
                        throw new RuntimeException(ex);
                    } catch (Exception ex) {
                        throw new RuntimeException(ex);
                    }
                }
                te_p2.setText(Spisoc);
            }
        });

        //===================================== Menu Lab =================
        JMenuBar jMB = new JMenuBar(); // Menu Bar
        f.setJMenuBar(jMB);
        JMenu jM, subjM;
        jM = new JMenu("Create"); // Name of menu
        subjM = new JMenu("Animal");
        JMenuItem jMenuCage= new JMenuItem("Cage"); // Sub-menu
        JMenuItem jMenuAF = new JMenuItem("Animal-Fish"); // Sub-menu
        JMenuItem jMenuABe = new JMenuItem("Animal-Beast");
        JMenuItem jMenuABi = new JMenuItem("Animal-Bird");
        jM.add(jMenuCage);
        subjM.add(jMenuABe);
        subjM.add(jMenuABi);
        subjM.add(jMenuAF);
        jM.add(subjM);
        jMB.add(jM);
        //=================================================================

        jMenuCage.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JDialog jd_C = new JDialog();
                jd_C.setResizable(false);
                jd_C.setVisible(true);
                jd_C.setSize(400, 200);

                JPanel jd_C_p = new JPanel();

                JLabel jLC_1 = new JLabel("Number of cage:= ");
                jLC_1.setBounds(10,5, 200 ,30);
                JTextField jTC_1 = new JTextField();
                jTC_1.setBounds(130, 5, 200, 30);

                JLabel jLC_2 = new JLabel("Size of cage:= ");
                jLC_2.setBounds(10,40,200,30);
                JTextField jTC_2 = new JTextField();
                jTC_2.setBounds(130,40,200,30);

                JLabel jLC_3 = new JLabel("Capasity of cage:= ");
                jLC_3.setBounds(10,75,200,30);
                JTextField jTC_3 = new JTextField();
                jTC_3.setBounds(130,75,200,30);

                JButton jBC = new JButton("Create!");
                jBC.setBounds(80,110,200,30);

                jBC.addActionListener(new ActionListener() {
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        if (!(jTC_1.getText()).equals("") && !(jTC_2.getText()).equals("") && !(jTC_3.getText()).equals("")){
                            Cage newCage = new Cage(Integer.valueOf(jTC_1.getText()),Integer.valueOf(jTC_2.getText()),Integer.valueOf(jTC_3.getText()),0);
                            l_p1.addElement(newCage);
                            NPark.setCells(newCage);
                        }
                        else JOptionPane.showMessageDialog(jd_C, "Re do the data!");
                    }
                });

                jd_C.add(jLC_1);
                jd_C.add(jTC_1);
                jd_C.add(jLC_2);
                jd_C.add(jTC_2);
                jd_C.add(jLC_3);
                jd_C.add(jTC_3);
                jd_C.add(jBC);
                jd_C.add(jd_C_p);

                jd_C.setTitle("Creating the Cage");
            }
        });
        jMenuAF.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JDialog jd_A = new JDialog();
                jd_A.setResizable(false);
                jd_A.setVisible(true);
                jd_A.setSize(400, 350);

                JPanel jd_A_p = new JPanel();

                JLabel jLA_1 = new JLabel("Name of animal:= ");
                jLA_1.setBounds(10,5, 200 ,30);
                JTextField jTA_1 = new JTextField();
                jTA_1.setBounds(130, 5, 200, 30);

                JLabel jLA_2 = new JLabel("Predator y/n:= ");
                jLA_2.setBounds(10,40,200,30);

                JTextField jTA_2 = new JTextField();
                jTA_2.setBounds(130,40,200,30);

                JLabel jLA_3 = new JLabel("Cage of animal:= ");
                jLA_3.setBounds(250,75,200,30);

                JLabel jLA_4 = new JLabel("Deep dweller y/n:=");
                jLA_4.setBounds(10, 110, 200, 30);

                JTextField jTA_3 = new JTextField();
                jTA_3.setBounds(130,110,200,30);

                JLabel jLA_5 = new JLabel("");
                jLA_5.setBounds(10,140,200,30);

                JButton jBA = new JButton("Create!");
                jBA.setBounds(80,250,200,30);

                DefaultListModel<Cage> jLA = new DefaultListModel<>();

                for (Cage c: NPark.getCells()) {jLA.addElement(c);}
                JList<Cage> l_jLA = new JList<>(jLA);
                l_jLA.setPreferredSize(new Dimension(30,30));

                jBA.addActionListener(new ActionListener() {
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        String s="";
                        if (!(jTA_1.getText()).equals("") && !(jTA_2.getText()).equals("") && !(jTA_3.getText()).equals("")){
                            s = jTA_1.getText();
                            if ((jTA_2.getText()).equals("y") && (jTA_3.getText().equals("y"))){
                                Fish newFish = new Fish(true,s,true,l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newFish);
                            } else if ((jTA_2.getText()).equals("y") && (jTA_3.getText().equals("n"))) {
                                Fish newFish = new Fish(false,s,true,l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newFish);
                            } else if ((jTA_2.getText()).equals("n") && (jTA_3.getText().equals("n"))) {
                                Fish newFish = new Fish(false,s,false,l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newFish);
                            } else if ((jTA_2.getText()).equals("n") && (jTA_3.getText().equals("y"))) {
                                Fish newFish = new Fish(true,s,false,l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newFish);
                            }

                        }
                        else JOptionPane.showMessageDialog(jd_A, "Re do the data!");
                    }
                });
                jd_A.add(jLA_1);
                jd_A.add(jTA_1);
                jd_A.add(jLA_2);
                jd_A.add(jTA_2);
                jd_A.add(jLA_3);
                jd_A.add(jTA_3);
                jd_A.add(jBA);
                jd_A.add(jd_A_p);
                jd_A.add(l_jLA, BorderLayout.LINE_END);
                jd_A.add(jLA_4);
                jd_A.add(jLA_5);
                jd_A.setTitle("Creating the Animal");
            }
        });

        jMenuABi.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JDialog jd_A = new JDialog();
                jd_A.setResizable(false);
                jd_A.setVisible(true);
                jd_A.setSize(400, 350);

                JPanel jd_A_p = new JPanel();

                JLabel jLA_1 = new JLabel("Name of animal:= ");
                jLA_1.setBounds(10,5, 200 ,30);
                JTextField jTA_1 = new JTextField();
                jTA_1.setBounds(130, 5, 200, 30);

                JLabel jLA_2 = new JLabel("Predator y/n:= ");
                jLA_2.setBounds(10,40,200,30);

                JTextField jTA_2 = new JTextField();
                jTA_2.setBounds(130,40,200,30);

                JLabel jLA_3 = new JLabel("Cage of animal:= ");
                jLA_3.setBounds(250,75,200,30);

                JLabel jLA_4 = new JLabel("Speed:=");
                jLA_4.setBounds(10, 110, 200, 30);

                JTextField jTA_3 = new JTextField();
                jTA_3.setBounds(130,110,200,30);

                JLabel jLA_5 = new JLabel("");
                jLA_5.setBounds(10,140,200,30);

                JButton jBA = new JButton("Create!");
                jBA.setBounds(80,250,200,30);

                DefaultListModel<Cage> jLA = new DefaultListModel<>();
                for (Cage c: NPark.getCells()) {jLA.addElement(c);}
                JList<Cage> l_jLA = new JList<>(jLA);
                l_jLA.setPreferredSize(new Dimension(30,30));

                jBA.addActionListener(new ActionListener() {
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        String s="";
                        if (!(jTA_1.getText()).equals("") && !(jTA_2.getText()).equals("") && !(jTA_3.getText()).equals("")){
                            if (jTA_2.getText().equals("y")){
                                Bird newBird = new Bird(Integer.valueOf(jTA_3.getText()), jTA_1.getText(), true, l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newBird);
                            } else if (jTA_2.getText().equals("n")) {
                                Bird newBird = new Bird(Integer.valueOf(jTA_3.getText()), jTA_1.getText(), false, l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newBird);
                            }
                        }
                        else JOptionPane.showMessageDialog(jd_A, "Re do the data!");
                    }
                });
                jd_A.add(jLA_1);
                jd_A.add(jTA_1);
                jd_A.add(jLA_2);
                jd_A.add(jTA_2);
                jd_A.add(jLA_3);
                jd_A.add(jTA_3);
                jd_A.add(jBA);
                jd_A.add(jd_A_p);
                jd_A.add(l_jLA, BorderLayout.LINE_END);
                jd_A.add(jLA_4);
                jd_A.add(jLA_5);
                jd_A.setTitle("Creating the Animal");
            }
        });

        jMenuABe.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JDialog jd_A = new JDialog();
                jd_A.setResizable(false);
                jd_A.setVisible(true);
                jd_A.setSize(400, 350);

                JPanel jd_A_p = new JPanel();

                JLabel jLA_1 = new JLabel("Name of animal:= ");
                jLA_1.setBounds(10,5, 200 ,30);
                JTextField jTA_1 = new JTextField();
                jTA_1.setBounds(130, 5, 200, 30);

                JLabel jLA_2 = new JLabel("Predator y/n:= ");
                jLA_2.setBounds(10,40,200,30);

                JTextField jTA_2 = new JTextField();
                jTA_2.setBounds(130,40,200,30);

                JLabel jLA_3 = new JLabel("Cage of animal:= ");
                jLA_3.setBounds(250,75,200,30);

                JLabel jLA_4 = new JLabel("place name:=");
                jLA_4.setBounds(10, 110, 200, 30);

                JTextField jTA_3 = new JTextField();
                jTA_3.setBounds(130,110,200,30);

                JLabel jLA_5 = new JLabel("");
                jLA_5.setBounds(10,140,200,30);

                JButton jBA = new JButton("Create!");
                jBA.setBounds(80,250,200,30);

                DefaultListModel<Cage> jLA = new DefaultListModel<>();
                for (Cage c: NPark.getCells()) {jLA.addElement(c);}
                JList<Cage> l_jLA = new JList<>(jLA);
                l_jLA.setPreferredSize(new Dimension(30,30));

                jBA.addActionListener(new ActionListener() {
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        String s="";
                        if (!(jTA_1.getText()).equals("") && !(jTA_2.getText()).equals("") && !(jTA_3.getText()).equals("")){
                            if (jTA_2.getText().equals("y")){
                                Beast newBeast = new Beast(jTA_3.getText(), jTA_1.getText(), true, l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newBeast);
                            } else if (jTA_2.getText().equals("n")) {
                                Beast newBeast = new Beast(jTA_3.getText(), jTA_1.getText(), false, l_jLA.getSelectedValue());
                                l_jLA.getSelectedValue().addPassenger(newBeast);
                            }
                        }
                        else JOptionPane.showMessageDialog(jd_A, "Re do the data!");
                    }
                });
                jd_A.add(jLA_1);
                jd_A.add(jTA_1);
                jd_A.add(jLA_2);
                jd_A.add(jTA_2);
                jd_A.add(jLA_3);
                jd_A.add(jTA_3);
                jd_A.add(jBA);
                jd_A.add(jd_A_p);
                jd_A.add(l_jLA, BorderLayout.LINE_END);
                jd_A.add(jLA_4);
                jd_A.add(jLA_5);
                jd_A.setTitle("Creating the Animal");
            }
        });

        JMenu fileM;
        fileM = new JMenu("File");
        JMenuItem fMNew = new JMenuItem("New");
        JMenuItem fMOp = new JMenuItem("Open");
        JMenuItem fMSave = new JMenuItem("Save");
        fileM.add(fMNew);
        fileM.add(fMOp);
        fileM.add(fMSave);
        jMB.add(fileM);

        //inviz
        jMenuCage.setEnabled(false);
        subjM.setEnabled(false);

        fMNew.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                l_p1.removeAllElements();
                l_p2.removeAllElements();
                f_l_p1.clearSelection();
                f_l_p2.clearSelection();

                String newPark;
                newPark = JOptionPane.showInputDialog(f, "Name of the zoo");
                NPark.setName(newPark);
                f.setTitle(newPark);
                jMenuCage.setEnabled(true);
                subjM.setEnabled(true);
                te_p2.setText("");
            }
        });
        fMOp.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                l_p1.removeAllElements();
                l_p2.removeAllElements();
                f_l_p1.setModel(l_p1);
                f_l_p2.setModel(l_p2);
                f_l_p1.clearSelection();
                f_l_p2.clearSelection();
                te_p2.setText("");

                JFileChooser jFC = new JFileChooser();
                jFC.showOpenDialog(f);
                String path = jFC.getSelectedFile().getPath();
                Zoo ParkNew = writ.LoadZoo(path);
                NPark.cells = ParkNew.cells;
                for (Cage c: NPark.getCells()) { l_p1.addElement(c);}
                jMenuCage.setEnabled(true);
                subjM.setEnabled(true);
            }
        });
        fMSave.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                JFileChooser jFCS = new JFileChooser();
                jFCS.showSaveDialog(f);
                String path = jFCS.getSelectedFile().getPath();
                writ.WriteZoo(NPark, path);
            }
        });
        //=================================================================
        tp.setBounds(5,5,600,300);
        b_sfom.setBounds(5,305,150,30);

        tp.add(p1, BorderLayout.LINE_START,0);
        tp.setTitleAt(0,"Cage info");
        tp.add(p2, BorderLayout.LINE_END, 1); // Aniamls
        tp.setTitleAt(1, "Animals");

        f.add(b_sfom);
        f.add(tp);

        f.setSize(625,400); // main panel size
        f.setLayout(null);
        f.setVisible(true);
    }
}
class writ{
    public static void WriteZoo(Zoo ParkS, String calling){
        try {
            FileOutputStream fileOutput = new FileOutputStream(calling);
            ObjectOutputStream objectOutput = new ObjectOutputStream(fileOutput);
            objectOutput.writeObject(ParkS);
            fileOutput.close();
            objectOutput.close();

        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }
    public static Zoo LoadZoo(String calling) {
        try {
            FileInputStream fileInput = new FileInputStream(calling);
            ObjectInputStream objectInput = new ObjectInputStream(fileInput);
            Zoo Parkl = (Zoo)objectInput.readObject();
            return Parkl;
        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        } catch (IOException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
}
