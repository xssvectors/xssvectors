   M S B A M L   `   `   `  ���� E  AXSSVectors, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:XSSVectors
XSSVectors  I E3DTools, Version=1.0.7637.19879, Culture=neutral, PublicKeyToken=null4'clr-namespace:_3DTools;assembly=3DTools_3DTools     XSSVectors.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:XSSVectors     :tool3d'clr-namespace:_3DTools;assembly=3DTools       � Title$  
MainWindow��$	��600��$	��800�� � 	Resources  
  rotate �� Rotation �� Axis �� Angle �� ElementName �� Path �� Mode��%S   &	        ��  �� $ 0,1,05� �� $ slider��$ Value�$ TwoWay=�.��� $��5q� � RowDefinitions �� $��2* ��� $��1* ��� $
��0.2* �.+��� 
�������$��1q�$��0��._�'� 	 '� Camera	 =� -   perspcam��
 � Position$
 1.4,4,41� � LookDirection$ -1,-3,-35� � UpDirection$ 0,1,05�.x�!  _3DTools.ScreenSpaceLines3D  -   
ssl3dX��   Points �      Color$	 Red�� g� 	Transform# [    -   
ssl3dY�� �   $ Green��# [    -   
ssl3dZ�� �   $
 Blue��# [    -   ssl3dconnect�� �      	Thickness$ 3Q�$ Black��# [  � $��1��$��0�� �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��vrsta0��$��0��$��0��$��23��$
��Left=�$��8,14,0,0q�$	��Top=�$	��127��$��Vrsta���� -   $��vrijednost0��$��1��$��0��$��23��$
��Left=�$��8,14,0,0q�$	��Top=�$	��127��$��1���� -   $��button1��$��1��$��0��$��23��$��
140,14,0,0q�$	��Top=�$
��Left=�$��76��.��
Add Item�� -	    ��Name$ lvVrijednosti0��$��2��$��0��$��10,10,10,10q� �� View �� .P��� $��Vrsta�� �� Width$	 100�� �� DisplayMemberBinding �� *Vrsta+�� $��
Vrijednost��$	 100�� �� *
Vrijednost+�� -
   $��vrsta1��$��0��$��1��$��23��$
��Left=�$��8,14,0,0q�$	��Top=�$	��127��$��Vrsta���� -   $��vrijednost1��$��1��$��1��$��23��$
��Left=�$��8,14,0,0q�$	��Top=�$	��127��$��1���� -   $��button2��$��1��$��1��$��23��$��
140,14,0,0q�$	��Top=�$
��Left=�$��76��.��
Add Item�� -   $ lvVrijednosti1��$��2��$��1��$��10,10,10,10q� �� .P��� $��Vrsta��$	 100�� �� *Vrsta+�� $��
Vrijednost��$	 100�� �� *
Vrijednost+�� -   $��vrsta2��$��0��$��2��$��23��$
��Left=�$��8,14,0,0q�$	��Top=�$	��127��$��Vrsta���� -   $��vrijednost2��$��1��$��2��$��23��$
��Left=�$��8,14,0,0q�$	��Top=�$	��127��$��1���� -   $��button3��$��1��$��2��$��23��$��
140,14,0,0q�$	��Top=�$
��Left=�$��76��.��
Add Item�� -   $ lvVrijednosti2��$��2��$��2��$��10,10,10,10q� �� .P��� $��Vrsta��$	 100�� �� *Vrsta+�� $��
Vrijednost��$	 100�� �� *
Vrijednost+�� -   $��
buttonPlus��$��0��$��3��$��23��$��	10,10,0,0q�$	��Top=�$
��Left=�$��76��.��+�� -   $��buttonMinus��$��1��$��3��$��23��$��	10,10,0,0q�$	��Top=�$
��Left=�$��76��.��-�� -   $��buttonReset��$��2��$��3��$��23��$��	10,10,0,0q�$	��Top=�$
��Left=�$��76��.��Reset�� -   $��slider��$��	10,5,5,10q�$��2�� � Minimum$ 0Q� � Maximum$	 360Q� �� Orientation$ 
Horizontal=�