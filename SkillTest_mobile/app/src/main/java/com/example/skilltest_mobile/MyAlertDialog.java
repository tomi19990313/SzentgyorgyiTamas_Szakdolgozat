package com.example.skilltest_mobile;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;



public class MyAlertDialog extends DialogFragment {
    String Title;
    String Message;

    MyAlertDialog(String title, String message)
    {
        this.Title = title;
        this.Message = message;
    }



    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        builder.setTitle(this.Title);
        builder.setMessage(this.Message);

        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) { }
        });

        return builder.create();
    }
}
