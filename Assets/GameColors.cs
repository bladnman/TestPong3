using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColors {
  // https://flatuicolors.com/palette/ru
  public static Color blue = GameColors.rgb(119, 139, 235);
  public static Color blueLight = GameColors.rgb(84, 109, 229);
  public static Color orange = GameColors.rgb(225, 95, 65);
  public static Color orangeLight = GameColors.rgb(231, 127, 103);
  public static Color yellow = GameColors.rgb(245, 205, 121);
  public static Color yellowLight = GameColors.rgb(247, 215, 148);
  public static Color peach = GameColors.rgb(241, 144, 102);
  public static Color peachLight = GameColors.rgb(243, 166, 131);
  public static Color purple = GameColors.rgb(87, 75, 144);
  public static Color purpleLight = GameColors.rgb(120, 111, 166);
  public static Color apple = GameColors.rgb(230, 103, 103);
  public static Color appleLight = GameColors.rgb(234, 134, 133);
  public static Color green = GameColors.rgb(32, 191, 107);
  public static Color greenLight = GameColors.rgb(38, 222, 129);
  public static Color pink = GameColors.rgb(235, 59, 90);
  public static Color pinkLight = GameColors.rgb(252, 92, 101);
  public static Color gray = GameColors.rgb(89, 98, 117);
  public static Color grayLight = GameColors.rgb(48, 57, 82);

  public static Color[] lights = new Color[] {
    blueLight,
    orangeLight,
    yellowLight,
    peachLight,
    purpleLight,
    appleLight,
    grayLight,
  };
  public static Color[] normals = new Color[] {
    blue,
    orange,
    yellow,
    peach,
    purple,
    apple,
    gray,
  };
  public static Color[] players = new Color[] {
    orange,
    yellow,
    peach,
    green,
    pink,
  };
  public static Color rgb(int r, int g, int b) {
    return new Color((float)r / 256, (float)g / 256, (float)b / 256);
  }
}
