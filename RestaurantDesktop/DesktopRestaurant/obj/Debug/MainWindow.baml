   M S B A M L   `   `   `  ����L  HDesktopRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DesktopRestaurantDesktopRestaurant  5   	   "    DesktopRestaurant.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:DesktopRestaurant     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � #��� ��6   .+�5
   
   �� $��	55,14,0,0q�6   $��Uživatelské jméno��6'   $
��Wrap=�6@   $
��Left=�6T   $��48��6o   $	��Top=�6{   $	��195��6�   $��18(�6�   �� 5   
   $��
55,124,0,0q�6   $��Heslo��6(   $
��Wrap=�65   $
��Left=�6I   $��44��6d   $	��Top=�6p   $	��152��6�   $��18(�6�    J� OpacityMask
 �   �6�   �� 5   
   -   5         ��Name$ txtUserName��5   l   $��
257,6,33,0q�6   $�� ��6&    �� TextWrapping$
 Wrap=�6.    �� MaxLines$ 1��6B    �� 	MaxLength$ 50��6O   $��12(�6^   $��0��6�   $��59��6�   $	��Top=�6�   
�������6�   G� 5   
   -   5         G�Name$ txtPassword��5   I   $��257,124,33,0q�6    G� 	MaxLength$ 32��6,   $��12(�6;   $��1��6^   $��59��6k   $	��Top=�6w   
�������6�   �� 5   
   -   5         ��Name$ btnLogin��5   �   $��	20,0,0,44q�6(   $��Bottom=�6;   $��96��6V   $��Přihlášení��6b   ���	#FFFFFFFF$��18(�6�   	 �� 	IsDefault	 . $��2��6�   $
��Left=�6�   $	��211��6�   ��5      �� 5      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ White��6#   $ 1Q�61   5      5      �� 5   
   -   5        $ Cancel��5   �   $��360,0,221,44q�6)   $��Bottom=�6?   $��96��6Z   $��Zrušit��6f   ���	#FFFFFFFF$��18(�6�   	 . $��2��6�    J� RenderTransformOrigin$ 2.403,0.645&�6�   ��5      �� 5      $
 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ White��6#   $ 1Q�61   5      5      5      5       