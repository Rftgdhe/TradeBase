   M S B A M L   `   `   `  ����J  FStoloviePribori, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StoloviePriboriStoloviePribori  5   	   #    StoloviePribori.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:StoloviePribori     5   	   -   5          � Title$  Авторизация��5   	   $	��400��6   $	��420��6*    � WindowStyle$
 None=�5	   	    � AllowsTransparency . 
������ .��5      ��  �� CornerRadius$ 20��6      
FocusColor#��[  6   ._�5   
   � $	��400��6   $	��Top=�6   .+�5      �� .+�5      ]� .+�5      �� $��Авторизация��6   $��Center=�62   $��20(�6O   5      ]� 5      $��0,5,0,15q�6   .+�5      �� $��Логин  ��6   $
��Left=�6.   $	��Top=�6J   $��27��6c   �� 5      -   5         ��Name$ LoginTextBox��5      $
��Left=�64   $��23��6O    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��321��6�   5      ]� 5      $��0,5,0,15q�6   .+�5      �� $��Пароль��6   $
��Left=�6-   $	��Top=�6I   $��26��6b   �� 5      -   5        $ PasswordPasswordBox��5      $
��Left=�6;   $��23��6V   $	��320��6d   5      ]� 5!      $��0,5,0,0q�6   .+�5"      �� $��
Капча��6   $
��Left=�6,   $	��Top=�6H    J� RenderTransformOrigin$ 0.535,1.231&�6`   �� 5#      -   5         ��Name$ CapchaImage��5#      $
��Left=�61   $��10,5,0,0q�6L   $	��100��6^   $	��Top=�6k   $	��182��6�   �� 5%      -   5         ��Name$ ChangeCaptchaButton��5%      $��Сменить��6:   $��75��6L   $	��Top=�6W   $��22��6o   $��4��6|   6�   5'      ]� 5(      .+�5)      �� $��Текст капчи��6   $
��Left=�62   $	��Top=�6M   �� 5*      -   5        $ CaptchaTextBox��5*      $��23��67   $
 Wrap=�6D   $	��244��6Y   5,      ]� 5-      $��25��6   $��0,14,0,0q�6(   ��.  .+�5.      �� -   5        $
��Ок��5.      $��Right=�5/      $	��Top=�50      $��75��65   51      �� 52      -   5        $��Отмена��52      $��Right=�53      $	��Top=�54      $��75��65   55      56      57      �� 5<      $y�	Collapsed=�6   5>      5@      5A      5B      