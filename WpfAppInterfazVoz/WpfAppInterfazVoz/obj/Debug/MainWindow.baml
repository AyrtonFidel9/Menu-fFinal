   M S B A M L   `   `   `  ����L  HWpfAppInterfazVoz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfAppInterfazVozWpfAppInterfazVoz  5   	   "    WpfAppInterfazVoz.MainWindow   5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfAppInterfazVoz     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	     � WindowStartupLocation$  CenterScreen=�5
   	   $��0q�5   	   (  "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � 
ResizeMode$ 	CanResize=�5   	      WindowTransitionsEnabled .   � Title$ Reconocimiento de voz��5   	   $��638.25��6'   $	��508��67    � 	Resources 5         lobster �� Property �� Value 	 patua��%�   &	        &	 S     �� 5   
   .�5      ��  � ��$ /Fonts/#Lobster-Regular)�67   5      �� 5   
   .�5      ��  � ��$ /Fonts/#PatuaOne-Regular)�67   5      5      .��5      � ���	#FF0069B0 � DataContext 5   
   ?  9Microsoft.Xaml.Behaviors.Media.StoryboardCompletedTrigger  5      .+�5   
   �� $��Interfaz de voz��6   $��50(�6*   $
��Left=�68   $��	98,10,0,0q�6S   $	��Top=�6f   
������ $1��+/WpfAppInterfazVoz;component/Fonts/#Lobster)�6�   ��5      �� 5       	 �� EndPoint$	 0.5,1&�6&   
 � MappingMode$
 RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5!      �  � Color$ 	#FFCFCFCF��6#    � Offset$ 1Q�65   � 5"      $ White��6#   $ 0.241Q�61   5#      5%      �� 5&   
   -   5         ��Name$ 
btnIniciar��5&      $��Iniciar��6%   $��56,519,275,36q�67   $��23(�6N   $3��-/WpfAppInterfazVoz;component/Fonts/#Patua One)�6u   $��Normal"�6�   �� 5'   
   -   5        $ 	btnPausar��5'      $��Pausar��6$   $��279,519,60,36q�65   $��23(�6L   $��Normal"�6r   $3��-/WpfAppInterfazVoz;component/Fonts/#Patua One)�6�   � 5(   
   $	��122��6   $��58,104,60,0q�6   $	��Top=�61    J� OpacityMask# � ��6I    J� Opacity$	 0.9Q�6�   ��5)      
� 5*      .��5+      � $ 	#FF0CF0D1��6#   $ 0Q�65   � 5,      $ 	#FF0CD9FA��6#   $ 1Q�65   5-      .+�5/      �� -   5         ��Name$ 
txtParrafo��5/      $��66,36,65,37q�6*    �� TextWrapping$
 Wrap=�6?   $��30(�6S    �� TextAlignment$ Center=�6a   
�������$3��-/WpfAppInterfazVoz;component/Fonts/#Patua One)�6�   
���   �6�   50      � 51   
   $	��226��6   $��58,256,60,0q�6   $	��Top=�61   $	 0.9Q�6I   ��52      �� 53      $	 0.5,1&�6&   $ 0.5,0&�67   .��54      � $ 	#E50CD9FA��6#   � 55      $ 	#FF0CF0D1��6#   $ 1Q�65   56      .+�58      �� -   5         ��Name$ 	imgImagen��58      $��90,10,76,12q�6'   59      5;      5<      