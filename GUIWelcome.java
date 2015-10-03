package hungrysnake;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
/**
 *
 * @author ibm
 */
public class GUIWelcome {
    JPanel contentPane;
    JFrame frame;
    JLabel welcome, highest, select;
    JButton ok, end;
    JComboBox level;
    Font f1 = new Font("Times New Roman", Font.BOLD, 20);
    Font f = new Font("Times New Roman", Font.BOLD, 15);
    
    public GUIWelcome() {
        frame = new JFrame("Welcome to Hungry Snake!");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        contentPane = new JPanel();
        contentPane.setLayout(new BoxLayout(contentPane, BoxLayout.PAGE_AXIS));
        contentPane.setBorder(BorderFactory.createEmptyBorder(12, 12, 12, 12));
        welcome = new JLabel("Welcome to Hungry Snake!");
        welcome.setFont(f1);
        welcome.setAlignmentX(JLabel.CENTER_ALIGNMENT);
        welcome.setBorder(BorderFactory.createEmptyBorder(5, 12, 5, 12));
        highest = new JLabel("Your highest mark is ");
        highest.setFont(f);
        highest.setAlignmentX(JLabel.CENTER_ALIGNMENT); 
        highest.setBorder(BorderFactory.createEmptyBorder(5, 12, 5, 12));
        select = new JLabel("Please select the level of game: ");
        select.setFont(f);
        select.setAlignmentX(JLabel.CENTER_ALIGNMENT); 
        select.setBorder(BorderFactory.createEmptyBorder(5, 12, 5, 12));
        String[] list = {"EASY", "MEDIUM", "HARD"}; 
        level = new JComboBox(list);
        level.setAlignmentX(JComboBox.CENTER_ALIGNMENT);
        level.setSelectedIndex(0); //Set the original rate to be 1
        ok = new JButton("OK!");
        ok.setFont(f);
        ok.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String levelGet = (String)level.getSelectedItem();
                
                frame.setVisible(false); 
            }
        });
        ok.setAlignmentX(JLabel.CENTER_ALIGNMENT); 
        ok.setBorder(BorderFactory.createEmptyBorder(5, 12, 5, 12));
        end = new JButton("End");
        end.setFont(f);
        end.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                
            }
        });
        end.setAlignmentX(JLabel.CENTER_ALIGNMENT); 
        end.setBorder(BorderFactory.createEmptyBorder(5, 12, 5, 12));
        contentPane.add(welcome);
        contentPane.add(highest);
        contentPane.add(select);
        contentPane.add(level);
        contentPane.add(ok);
        contentPane.add(end);
        frame.setContentPane(contentPane);
        frame.pack();
        frame.setVisible(true); 
        frame.setLocationRelativeTo(null); 
    }
    private void runGUI() {
        JFrame.setDefaultLookAndFeelDecorated(true);
        GUIWelcome welcome = new GUIWelcome();
    }
}
