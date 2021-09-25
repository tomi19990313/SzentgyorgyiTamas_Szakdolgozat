// Interface to call the appropriate functions, what it has
// It will be called to be representing the query success


package com.example.skilltest_mobile;

import java.util.Map;



public interface InterfaceForCheck{
    void successful(Map<String, String> resultMap);
    void failure();
}
