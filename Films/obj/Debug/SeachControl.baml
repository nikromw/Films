   M S B A M L   `   `   `  ����@  <Films, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FilmsFilms  5          Films.SeachControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Films     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  dgFilms��5
         AutoGenerateColumns .  $��0,57,-0.4,0q�6@      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6F      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Title�6U     5      $ Runtime��6H   $ * 6Y    6%   �� $ Runtime�6Y     5      $
 Year��6K   $ * 6Y    6%   �� $ 
YearOfFilm�6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Image��6)   $ * 68      CellTemplate 5      �� 5      .R�5      �� $��64��6$   ��6/   �� $ Poster�5      5        5      $ Genre��6F   $ * 6U    6%   �� $ Genre�6U     5      $ Writer��6G   $ * 6W    6%   �� $ Writer�6W     5      $ Favorite��6)   $ * 6;    5      �� 5      .R�5      �� -   5         d� 	IsChecked 5   '   �� $ 	IsFavorit�	 �� UpdateSourceTrigger$	 PropertyChanged=�6t   5      5      5       �� 5!   
   -   5        
 ��Name$
 
SearhField��5!      $
��Left=�6&   $��23��6A   $��	10,29,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6u   $	��334��6�    J� RenderTransformOrigin$ -0.81,-3.487&�6�   6�   �� 5"   
   $
��Left=�6   $��10,8,0,0q�6/   $
��Wrap=�6A   $��Input title of the film��6U   $	��Top=�6t   $ -0.944,0.325&�6�   $	��126��6�   �� 5#   
   -   5        $��Search��5#      $
��Left=�6"   $��
349,29,0,0q�6=   $	��Top=�6Q   $��75��6i   $��23��6t   6�   �� 5%   
    �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $��Right=�6F   .+�5&      �� -   5        $��To Favorites��5&      $��	0,0,0,0.2q�6,   $��85��6?   $��35��6J   6V   5'       � 5(   
   -   5          �Name$ frame��5(      $��0,0,0,0q�6     � NavigationUIVisibility$ Hidden=�60   5)      5*      