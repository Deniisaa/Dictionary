   M S B A M L   `   `   `  ����  
Dictionary    DictionaryApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Dictionary App��5   	   $	��450��6    $	��800��6-   
�������.��5	      � .+�5   
   � -   5         �Name$ LoginInterface��5      .+�5      �� .@�5      �� $��Administrative��6   .��5      � .+�5      �� $��	Username:��6    $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   �� 5      -   5         ��Name$ txtUsername��5   "   $
��Left=�67   $��	90,10,0,0q�6R   $	��Top=�6e   $	��150��6}   �� 5      $��	Password:��6    $
��Left=�64   $��
260,10,0,0q�6O   $	��Top=�6c   G� 5      -   5         G�Name$ txtPassword��5   &   $
��Left=�6;   $��
340,10,0,0q�6V   $	��Top=�6j   $	��150��6�   �� 5      -   5        $��Login��5   !   $
��Left=�61   $��
510,10,0,0q�6L   $	��Top=�6`   $��75��6x   6�   5      5      �� 5      $��Search��6   .��5      � .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� -   5        $��Select Category��5   )   ��5   &   �� 5    *    �� 
TargetType" ��6:   .R�5!   .   �� 
�������
�������$��2q�6Z    �� CornerRadius$ 4��6n   $	��100��6   $��30��6�   ._�5"   2   �� $��Center=�6C   $��Center=�6`   5#   /   5$   +   5&   #   �� 5(   "   -   5         ��Name$ SelectCategoryComboBox��5(   +   $
��Left=�6K   $	��Top=�6f   $	��150��6~   $��10q�6�   $y�	Collapsed=�6�   6�   �� 5*   "   -   5        $ 	txtSearch��5*   *   $��10q�6=   $	��200��6I   $��30��6U   $
��Left=�6a   $	��Top=�6|   6�   �� 5,   "   -   5        $��Search��5,   )   $��10q�6:   $	��100��6F   $��30��6R   $
��Left=�6^   $	��Top=�6y   ��5-   &   �� 5.   *   " ��6:   .R�5/   .   �� 
�������
�������$��1q�6Z   $ 4��6n   $	��100��6   $��30��6�   ._�50   2   �� $��Center=�6C   $��Center=�6`   51   /   52   +   54   #   55      �� 57      -	   5         ��Name$ lstWordSuggestions��57   &   $��	102,0,0,0q�6C   $	��200��6V   $	��100��6b   $
��Left=�6o   $	��Top=�6�   $y�	Collapsed=�6�   6�   � 59      -
   5        $ WordDetailsGrid��59   #   $y�	Collapsed=�6<   	 � RowDefinitions	 5:   "   �� 5;   &   $
��Auto �64   �� 5<   &   $
��Auto �64   �� 5=   &   $
��Auto �64   �� 5>   &   $
��Auto �64   .+�5@   "   �� $��Name:��6,   $
��Bold"�69   $��10q�6K   �� 5A   "   -   5        
 ��Name$
 WordNameTextBlock��5A   ,   $��0��6G   $��25q�6T   �� 5B   "   $��	Category:��6,   $
��Bold"�6=   $��1��6O   $��10q�6\   �� 5C   "   -   5        $
 CategoryTextBlock��5C   ,   $��1��6G   $��25q�6T   �� 5D   "   $��Description:��6,   $
��Bold"�6@   $��2��6R   $��10q�6_   �� 5E   "   -   5        $
 DescriptionTextBlock��5E   ,   $��2��6J   $��25q�6W   �� 5F   "   -   5         ��Name$ 	WordImage��5F   (   $��3��6;   $��10q�6H   $	��250��6T   $	��250��6`   5G      5H      5I      5J      �� 5M      $��Entertainment��6   .��5N      � .+�5O      �� .+�5P      �� $��Guess the word:��6(   $��10q�6?   �� 5Q      -   5        $ GuessTextBox��5Q   &   $��10q�6<   $	��200��6H   �� 5R      -   5         ��Name$ 
NextButton��5R   %   $
��Next��69   $��10q�6H   6T   �� 5S      -   5        $ PreviousButton��5S   %   $��Previous��6=   $��10q�6P   6\   5T      � 5V      -   5        $" EntertainmentWordDetailsGrid��5V      	 5W      �� 5X   "   $
��Auto �60   �� 5Y   "   $
��Auto �60   �� 5Z   "   $
��Auto �60   �� 5[   "   $
��Auto �60   .+�5]      �� $��Name:��6(   $
��Bold"�65   $��10q�6G   �� 5^      -   5        $$
 EntertainmentWordNameTextBlock��5^   (   $��0��6P   $��10q�6]   �� 5_      $��	Category:��6(   $
��Bold"�69   $��1��6K   $��10q�6X   �� 5`      -   5        $$
 EntertainmentCategoryTextBlock��5`   (   $��1��6P   $��10q�6]   �� 5a      $��Description:��6(   $
��Bold"�6<   $��2��6N   $��10q�6[   �� 5b      -   5        $'
 !EntertainmentDescriptionTextBlock��5b   (   $��2��6S   $��10q�6`   �� 5c      -   5        $ EntertainmentWordImage��5c   $   $��3��6D   $��10q�6Q   $	��250��6]   $	��250��6i   5d      5e      5f      5g      5i      � 5j   
   -   5        $ AdminControls��5j      $y�	Collapsed=�6&   .+�5l      �� .+�5m      �� -   5        $��Add Word��5m      $��10q�6,   68   �� 5o      -   5         ��Name$ WordDetailsPanel��5o      $y�	Collapsed=�67   .+�5q      �� -   5        $
 txtNewWordNameLabel��5q       $��
Word Name:��6=   $	��0 5q�6O   $y�	Collapsed=�6\   �� 5s      -   5        $ txtNewWordName��5s      $y�	Collapsed=�66   $	��200��6M   $��30��6Y   �� 5u      -   5        $ 
 txtNewWordDescriptionLabel��5u       $��Description:��6D   $	��0 5q�6X   $y�	Collapsed=�6e   �� 5w      -   5        $ txtNewWordDescription��5w      $y�	Collapsed=�6=   $	��200��6T   $	��100��6`    �� TextWrapping$
 Wrap=�6m   �� 5y      -   5        $
 CategoryListLabel��5y       $��	Category:��6;   $	��0 5q�6L   $y�	Collapsed=�6Y   �� 5{      -   5        $ CategoryList��5{      $	��150��65   $y�	Collapsed=�6A   �� 5}      -    5        $ btnSaveWord��5}      $
��Save��62   $y�	Collapsed=�6A   $��10q�6X   $��75��6d   $��30��6o   6{   5~      �� 5�      -!   5        $��Remove Word��5�      $��10q�6/   6;   �� 5�      -"   5        $��	Edit Word��5�      $��10q�6-   69   �� 5�      -#   5        $
��Back��5�      $��10q�6(   64   5�      5�      5�      5�      