package com.example.user.sensorblockchain;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity implements SensorEventListener {
  SensorManager sensor;
  TextView  xid;
  TextView  yid;
  TextView  zid;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);


        sensor = (SensorManager)this.getSystemService(SENSOR_SERVICE);

        Sensor linearAcceleration;


        // use this link to know more
        //https://developer.android.com/guide/topics/sensors/sensors_motion.html

        linearAcceleration = sensor.getDefaultSensor(Sensor.TYPE_LINEAR_ACCELERATION); // initialization of LINEAR_ACCELERATION
        sensor.registerListener(this,linearAcceleration,SensorManager.SENSOR_DELAY_NORMAL);

        setContentView(R.layout.activity_main);
    }

    @Override
    public void onSensorChanged(SensorEvent event) {
        xid=(TextView)findViewById(R.id.idX);
        yid=(TextView)findViewById(R.id.idY);
        zid=(TextView)findViewById(R.id.idZ);
      xid.setText(Float.toString(event.values[0]));
      yid.setText(Float.toString(event.values[1]));
      zid.setText(Float.toString(event.values[2]));
    }

    @Override
    public void onAccuracyChanged(Sensor sensor, int accuracy) {

    }

    @Override
    public void onPointerCaptureChanged(boolean hasCapture) {

    }
}
