   M S B A M L   `   `   `  ����E  AMathYouCan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MathYouCan.ViewsMathYouCan.Views  5   	   "    MathYouCan.Views.PauseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MathYouCan.Views     5   	   -   5          � Title$  PauseWindow��5   	   $	��450��66   $	��800��6C    � WindowState$ 	Maximized=�6O    � WindowStyle$
 None=�6g   .��5	      �  � RowDefinitions 5   
   �� 5      $	��12* �6   �� 5      $��9* �6   �� 5      $	��73* �6   �� 5      $��7* �6   .+�5   
   �� $��0��6   ���#001733._�5      �  5      �� 5      $
��0.5* �6$   �� 5      $��1* �6$   �� 5      $
��0.5* �6$   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $��20,0,0,0q�6Q   $��1��5      .+�5!      �� -   5        $��actLogoImage��5!      $*��$pack://application:,,,/Img/large.png��60   $
��Fill=�6^    �� BitmapScalingMode$ HighQuality=�6m   5#      5&      5(      � 5*   
   $��1��6   .+�5+      �� -   5        $��examName��5+      $��20 0 0 0q�6$   $��Bottom=�66   $��30(�6Q   .��6_   64Your exam will continue immediately after the break:6�   �� 5,      ���#e42a22$��0,0,0,2q�6+   6G   5-      � 5.   
   $��2��6    5/      �� 50      $
��0.6* �6    60   �� 51      6"   �� 52      6"   .+�54      �� -   5        $��
TimerLabel��54      $��1��6&   $��Center=�63   $��Center=�6P   $
��Bold"�6k   $��65(�6}   .��6�   15:0056      57      58      59      