package com.example.skilltest_mobile;

import  androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import java.util.HashMap;
import java.util.Map;



public class QueryActivity extends AppCompatActivity {
    private LinearLayout linearLayout;
    private Button backButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_query);

        linearLayout = (LinearLayout) findViewById(R.id.LinearLayout);
        backButton = (Button) findViewById(R.id.button);

        this.showResults();

        backButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });
    }



    public void showResults(){
        String param = "";
        Bundle extras = getIntent().getExtras();

        if (extras != null){
            param = extras.getString("param");
            param = param.replace("{", "");
            param = param.replace("}", "");

            Map<String, String> myMap = new HashMap<String, String>();
            String[] pairs = param.split(", ");

            for (int i=0; i<pairs.length; i++) {
                String pair = pairs[i];
                String[] keyValue = pair.split("=");
                myMap.put(keyValue[0], keyValue[1]);
            }

            for(Map.Entry<String, String> entry : myMap.entrySet()){
                if (!entry.getKey().equals("ID"))
                {
                    TextView label = new TextView(this);
                    label.setText(entry.getKey());

                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MATCH_PARENT, LinearLayout.LayoutParams.MATCH_PARENT);
                    layoutParams.setMargins(0,60,0,0);

                    label.setLayoutParams(layoutParams);
                    linearLayout.addView(label);

                    String[] results = entry.getValue().split("_");

                    for (int i=0; i<results.length; i++){
                        TextView label2 = new TextView(this);
                        label2.setText("    " + results[i]);
                        linearLayout.addView(label2);
                    }
                }
            }
        }
    }
}
