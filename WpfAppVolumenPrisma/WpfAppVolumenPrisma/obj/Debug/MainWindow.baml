   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3ffCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5   	   N JWpfAppVolumenPrisma, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfAppVolumenPrismaWpfAppVolumenPrisma 5   	   $   WpfAppVolumenPrisma.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6mah,http://metro.mahapps.com/winfx/xaml/controls   5   	   :d2http://schemas.microsoft.com/expression/blend/2008   5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   PDialogCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro   5   	   -local!clr-namespace:WpfAppVolumenPrisma   5   	     � Title$   ��5
   	   $	��518��6   $��627.399��6   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$
 Gray��6   � 5      $ White��6    � Offset$ 0.179Q�6)   5       � 	Resources 5         Passion-Black �� Property �� Value  Passion-Regular  Passion-Bold  Open-SB��%�  &	        &	 X     &	 �     &	 	    �� 5   
   .�5      ��  � ��$ Fonts/#PassionOne-Black)�67   6Y   5      �� 5   
   .�5      ��  � ��$ Fonts/#PassionOne-Regular)�67   6[   5      �� 5   
   .�5      ��  � ��$ Fonts/#PassionOne-Bold)�67   6X   5      �� 5   
   .�5      ��  � ��$ Fonts/#OpenSans-SemiBold)�67   6Z   5      5      .��5       �  � ColumnDefinitions 5!   
   �� 5"      $	��23* �6   �� 5#      $
��288* �6   .+�5%   
   �� $
��Left=�6   $	��167��6+   $��
51,267,0,0q�68   $	��Top=�6L   $	��148��6d   $��Imagenes/piramidedef.png��6p   $��UniformToFill=�6�   $��1��6�   �� 5&   
   $��Datos��6   $
��Left=�6"   $	��148��6=   $��8,94,0,0q�6J   $	��Top=�6\   $	��337��6t   $��1��6�   ��5'      �� 5(      $ 0.5,1&�6&   $ 0.5,0&�67   .��5)      � $ 	#FFFFACAC��6#   $ 1Q�65   � 5*      $ 	#7FFFACAC��6#   5+      5-      �� 5/   
   -   5        	 ��Name$	 	lblTitulo��5/      $.��(Volumen de un Pirámide de base cuadrada��6#   $
��Left=�6U   $��17,21,0,426q�6p   $��30(�6�   $��1��6�   #��[ 6�   $7��1/WpfAppVolumenPrisma;component/Fonts/#Passion One)�6�   $	��487��6  �� 50   
   -   5        $	 	lblAltura��50      $��Ingrese la altura��6#   $
��Left=�6?   $��
22,138,0,0q�6Z   $	��Top=�6n   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   $	��124��6�   $��14(�6
  �� 51   
   -   5        $	 lblLadoBase��51      $ ��Ingrese el lado de la base��6%   $
��Left=�6J   $��
22,190,0,0q�6e   $	��Top=�6y   $��28��6�   $	��179��6�   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   $��14(�6   �� 52   
   -   5        
 ��Name$
 	txtAltura��52      $
��Left=�6%   $��23��6@   $��209,140,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   $��1��6�   �� 53   
   -   5        $
 txtLadoBase��53      $
��Left=�6'   $��23��6B   $��209,193,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   $��1��6�   �� 54   
   $��Unidades de Medida��6   $
��Left=�6/   $	��148��6J   $��
368,94,0,0q�6W   $	��Top=�6k   $	��145��6�   $��1��6�   ��55      �� 56      $ 0.5,1&�6&   $ 0.5,0&�67   .��57      � $ 	#7FFFFF7B��6#   � 58      $ 	#FFFFFF7B��6#   $ 1Q�65   59      .��5;      	� -   5         	�Name$ rdbMM��5;      $��mm��6)   $
��Left=�66   $��	46,85,0,0q�6Q   $	��Top=�6d   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   5<      	� 5=   
   -   5        $ rdbCM��5=      $��cm��6%   $
��Left=�62   $��419,182,0,0q�6M   $	��Top=�6b   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   	� 5>   
   -   5        $ rbdDM��5>      $��dm��6%   $
��Left=�62   $��419,155,0,0q�6M   $	��Top=�6b   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   	� 5?   
   -	   5        $
 rdbM��5?      $��m��6$   $
��Left=�60   $��419,129,0,0q�6K   $	��Top=�6`   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   �� 5@   
   -
   5        $	 lblAlturaFig��5@      $�� ��6&   $
��Left=�61   $��170,299,0,0q�6L   $	��Top=�6a   $
��Bold"�6y   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   �� 5A   
   -   5        $	 lblBase1Fig��5A      $�� ��6%   $
��Left=�60   $��185,408,0,0q�6K   $	��Top=�6`   $
��Bold"�6x   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   �� 5B   
   -   5        $	 lblBase2Fig��5B      $�� ��6%   $
��Left=�60   $��
29,424,0,0q�6K   $	��Top=�6_   $��49��6w   $
��Bold"�6�   $��1��6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   �� 5C   
   $��	Cálculos��6   $
��Left=�6%   $	��170��6@   $��313,270,0,0q�6M   $	��Top=�6b   $	��200��6z   $��1��6�   ��5D      �� 5E      $ 0.5,1&�6&   $ 0.5,0&�67   .��5F      � $ 	#31E0E0E0��6#   $ 0Q�65   � 5G      $ 	#FFE0E0E0��6#   $ 1Q�65   5H      .��5J      �� -   5         ��Name$ txtBVolumen��5J      $
��Left=�6-   $��	10,19,0,0q�6H   $
��Wrap=�6[   $	��Top=�6o   $	��170��6�   $��39��6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   $��15(�6�   #��[ 6�   $>��8/WpfAppVolumenPrisma;component/Fonts/#Open Sans SemiBold)�6�   5K      �� 5L   
   -   5         ��Name$ btnCalcular��5L      $��Center=�6&   $��Center=�6H   $��CALCULAR��6l   $
��Left=�6   $��351,356,0,0q�6�   $	��Top=�6�   $	��120��6�   $��30��6�   $��1��6�   #��[ 6O  $7��1/WpfAppVolumenPrisma;component/Fonts/#Passion One)�6p  $��16(�6�  �� 5N   
   $��	0,465,0,0q�6   $��2��6'   .@�5O      �� ��6   ��  �� ElementName$ MainTabControl�� �� Path$ SelectedItem.Header� �� Mode$ OneWay=�5P      �� 5Q   
   -   5        $ btnNuevoCalculo��5Q      $��Center=�6*   $��Center=�6L   $��NUEVO CÁLCULO��6p   $
��Left=�6�   $��351,396,0,0q�6�   $	��Top=�6�   $	��120��6�   $��30��6�   $��1��6�   #��[ 6[  $7��1/WpfAppVolumenPrisma;component/Fonts/#Passion One)�6|  $��16(�6�  5R      5T      