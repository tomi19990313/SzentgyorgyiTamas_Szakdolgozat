// Dialog to give an information window for the user, if something is wrong with the given values


package com.example.skilltest_mobile;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;



public class MyAlertDialog extends DialogFragment {
    String Title;    // Title text
    String Message;  // Message text

    MyAlertDialog(String title, String message)
    {
        this.Title = title;
        this.Message = message;
    }



    // Display the window, and set the texts
    @NonNull
    @Override
    public Dialog onCreateDialog(@Nullable Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());

        builder.setTitle(this.Title);
        builder.setMessage(this.Message);

        // Listening for the "OK" button click
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int id) { }
        });

        return builder.create();
    }
}
