package com.example.skilltest_mobile;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.DialogFragment;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;



public class MainActivity extends AppCompatActivity {
    private Button QueryButton;
    private EditText TeacherNameEditText;
    private EditText ChildNameEditText;
    private EditText ChildIDEditText;
    private FirebaseDatabase FirDatabase;
    private DatabaseReference DatabaseRef;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);

        QueryButton = (Button) findViewById(R.id.button);
        TeacherNameEditText = (EditText) findViewById(R.id.teacherNameEditText);
        ChildNameEditText = (EditText) findViewById(R.id.childNameEditText);
        ChildIDEditText = (EditText) findViewById(R.id.childIDEditText);
        FirDatabase = com.google.firebase.database.FirebaseDatabase.getInstance();
        DatabaseRef = FirDatabase.getReference("results");

        QueryButton.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                openQueryWindow();
            }
        });
    }



    public void openQueryWindow() {
        if ((this.ChildNameEditText.getText().length() == 0) || (this.ChildIDEditText.getText().length() == 0) || (this.TeacherNameEditText.getText().length() == 0))
        {
            DialogFragment myAlertDialog = new MyAlertDialog("Hiányzó adatok", "Töltsön ki minden mezőt!");
            myAlertDialog.show(getSupportFragmentManager(), "Info");

            return;
        }

        check(this.TeacherNameEditText.getText().toString() , this.ChildNameEditText.getText().toString(), this.ChildIDEditText.getText().toString(), this.TeacherNameEditText, this.ChildNameEditText, this.ChildIDEditText, new InterfaceForCheck() {

            @Override
            public void successful(Map<String, String> resultMap) {
                QueryActivity queryActivity = new QueryActivity();
                Intent QueryIntent = new Intent(MainActivity.this, queryActivity.getClass());

                QueryIntent.putExtra("param", resultMap.toString());

                startActivity(QueryIntent);
            }

            @Override
            public void failure() {
                DialogFragment myAlertDialog = new MyAlertDialog("Helytelen adatok", "Nem található gyerek ilyen adatokkal!");
                myAlertDialog.show(getSupportFragmentManager(), "Info");
            }
        });
    }



    public void check(final String teacher, final String child, final String childID, EditText teacherNameEditText, EditText childNameEditText, EditText childIDEditText, final InterfaceForCheck interfaceForCheck){
        DatabaseRef.addListenerForSingleValueEvent(new ValueEventListener() {

            @Override
            public void onDataChange(@NonNull DataSnapshot dataSnapshot) {
                Map<String, Map<String, Map<String, String>>> teachers = (HashMap<String, Map<String, Map<String, String>>>) dataSnapshot.getValue();

                try
                {
                    boolean autOK = (teachers.get(teacher).get(child).get("ID").equals(childID));

                    if (autOK) {
                        Map<String, String> resultMap = new HashMap<String, String>();
                        Set<String> keys = teachers.get(teacher).get(child).keySet();

                        for(String key: keys){
                            String value = teachers.get(teacher).get(child).get(key);

                            resultMap.put(key, value);
                        }

                        teacherNameEditText.setText("");
                        childNameEditText.setText("");
                        childIDEditText.setText("");

                        interfaceForCheck.successful(resultMap);
                    } else {
                        interfaceForCheck.failure();
                    }
                }
                catch (Exception e)
                {
                    interfaceForCheck.failure();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError databaseError) {
                DialogFragment myAlertDialog = new MyAlertDialog("Hiba", "Adatbázis hiba!");
                myAlertDialog.show(getSupportFragmentManager(), "Info");
            }
        });
    }
}
