   M S B A M L   `   `   `  ����I  EWpfAppAbonents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfAppAbonentsWpfAppAbonents  5   	   !    WpfAppAbonents.ListAbonents   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfAppAbonents     5   	     � Title$  ListAbonents��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   �� $��0��6   $
��Left=�6"   $��Center=�6=    �� Orientation$ 
Horizontal=�6X   .+�5      �� -   5         ��Name$ 
userNameTB��5      $��20(�6(   $��Тест��66   6G   �� 5      -   5         ��Name$ addBTN��5      $��Добавить��6%   $��20,0,0,0q�68   6a   �� 5      -   5        $ 	changeBTN��5      $��Изменить��6(   $��20,0,0,0q�6;   6g   �� 5      -   5        $ 	removeBTN��5      $��Удалить��6(   $��20,0,0,0q�6:   6f   �� 5      -   5         ��Name$ searchTB��5      $��20,0,0,0q�6(   $	��200��6:   6k   �� 5      -   5         ��Name$ 
searchToLB��5      $��20,0,0,0q�6+   $	��200��6=    �� SelectedIndex$ 0��6I   .@�5      �� .��6   Искать: телефон60   �� 5      .��6   Искать: фамилия60   5      5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ abonentsList��5      	 �� View	 5      �� 5      .P�5       �� $ ��Идентификатор��6)   
 �� Width$

 auto��6@    �� DisplayMemberBinding 6M   ��  �� Path$ Id�6x   �� 5!      $��Телефон��6)   $

 auto��6:    6G   �� $ Phone�6u   �� 5"      $��
Адрес��6)   $

 auto��68    6E   �� $ Address�6u   �� 5#      $��
Почта��6)   $

 auto��68    6E   �� $ Pochta�6t   �� 5$      $��Фамилия��6)   $

 auto��6:    6G   �� $ Surname�6w   �� 5%      $��Имя��6)   $

 auto��66    6C   �� $
 Name�6p   �� 5&      $��Отчество��6)   $

 auto��6;    6H   �� $ 
Patronymic�6{   5'      5)      5*      5+      5,      