   M S B A M L   `   `   `  ����E  AMathYouCan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MathYouCan.ViewsMathYouCan.Views  5   	   )    #MathYouCan.Views.InstructionsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MathYouCan.Views     5   	   -   5        $	��450��5   	   $	��800��6     � WindowStyle$
  None=�5	   	    � 
ResizeMode$ NoResize=�6   ���#f2f2f2.��5      �  � RowDefinitions 5   
   �� 5      $	��11* �6   �� 5      $	��82* �6   �� 5      $��7* �6   .+�5   
   �� $��0��6   ���#001733._�5      �  5      �� 5      $
��0.5* �6$   �� 5      $��1* �6$   �� 5      $
��0.5* �6$   .+�5!      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�66   $��20,0,0,0q�6Q   $��1��5"      .+�5$      �� -   5        $��actLogoImage��5$       �� BitmapScalingMode$ HighQuality=�60   �� 5&      -   5        $��
prevButton��5&      $
��Prev��6/   $��	50,0,10,0q�6>   $��65��5'      $��15(�6(   $
��Bold"�66   ���#F4F6F8{�.   � 	Resources 5)       �� 
TargetType �� Property �� Value��%^   '��       �� 5*      " ��6$   .�5+   "   ��  �@��CornerRadius$ 4��6A   5,      5-      5.      �� 51      -   5        $��
nextButton��51      $
��Next��6/   $��	10,0,10,0q�6>   $��65��52      $��15(�6(   $
��Bold"�66   ���#F4F6F8 54      ��%^   '��       �� 55      " ��6$   .�56   "   ��  �@��CornerRadius$ 4��6A   57      58      59      5;      5>      5@      �� 5D   
   $��1��6   ._�5F      �  5H      �� 5J      $
��0.2* �6$   �� 5K      .+�5O      �� $��0��6   $��Center=�6*   .+�5P      �� -   5        $!��instructionSectionNameLabel��5P      $��18(�6?   $
��Bold"�5Q      $��30,0,0,0q�6.   5R      �� 5U      $��1��6   $��30,0,0,0q�6*   .+�5Z      ,� -   5        $��instructionContent��5Z   /   "	 ,� VerticalScrollBarVisibility$	 Disabled=�6I   $
 ,� HorizontalScrollBarVisibility$
 Disabled=�5[   /   .��5]      /� .T�5^      J� -   5         �Name$! instructionContentParagraph��5^   (    �� Margin$ 0q�6K   .*�6V   5_      5`      5a      �� 5e      -   5        $��acceptDeclineStackPanel��5e   !   $ 
Horizontal=�6@   $��0,40,0,0q�6Y   $y�Hidden=�5f   !   .+�5j      �� -	   5        $��acceptButton��5j   !   $��75��65   $��23��6@   $��Accept��6L    5k      ��%^   '��       �� 5l   "   " ��6(   .�5m   &   ��  �@��CornerRadius$ 5��6E   5n   #   5o      5p      5s      5u      5w      5y      �� 5}   
   $��2��6   
�������._�5      �  5�      �� 5�      �� 5�      �� 5�      $
��0.1* �6$   .+�5�      �� |�.  $��2��62   $��Stretch=�6C   $
��Auto=�6a   .��5�      �� -
   5         ��Name$ questionsStackPanel��5�   !   $ 
Horizontal=�6>    �� CanHorizontallyScroll .  5�      5�      5�      5�      5�      5�      