   M S B A M L   `   `   `  ����B  >WPFlab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFlab2WPFlab2  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       WPFlab2.TopmostWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPFlab2     5   	   6enu&clr-namespace:System;assembly=mscorlib     5   	     � Title$  Add new Employee��5	   	   $	��500��6"   $	��500��6/    � Topmost .  � 
ResizeMode$ CanMinimize=�6J    � WindowStartupLocation$ CenterScreen=�5
   	   $��14(�6.    � 	Resources 5       	  Roles S� 
MethodName S� 
ObjectType  System.Enum S� MethodParameters M� TypeName  
Currencies 
 Cstyle	 �� 
TargetType
 �� Property �� Value��%l  &	        &	 k     &	 �     S� 5   
   $ 	GetValues��6+   "  5       5      M� 5      $ 
local:Role��6   5      S� 5   
   $ 	GetValues��60   "  5       5      M� 5      $ local:Currency��6   5      �� 5   
   "	 �6   .�5      �� 
 � ��$ 4q�6'   63   �� 5      
 � ��$ Center=�62   5      5      .��5      � $��50q�6    5   
    �� BasedOn��%�   '��       7  '��      7  '�� :     7  '	� W     7  '�� t     7  �� 5       8   "	 ��66   �� 5!      8   "	 ��66   �� 5"      8   "	 ��66   �� 5#      8   "	 	�66   �� 5$      8   "	 ��66   5%       � ColumnDefinitions 5&   
   �� 5'      �� 5(      $��2* �6    � RowDefinitions 5*   
   �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      �� 51      �� 52      �� 53      �� 54      .+�56   
   �� $��First Name:��6   �� 57   
   $��
Last Name:��6   $��1��6&   �� 58   
   $
��Sex:��6   $��2��6    $��2��6-   $��Center=�6>   �� 59   
   $��Birth Date:��6   $��4��6'   �� 5:   
   $��Birth Country:��6   $��5��6*   �� 5;   
   $��Salary:��6   $��6��6#   �� 5<   
   $��Salary Currency:��6   $��7��6,   �� 5=   
   $��Company Role:��6   $��8��6)   �� 5>   
   -   5        $��	FirstName��5>      $��1��6#   �� 5?   
   -   5        $��LastName��5?      $��1��6"   $��1��62   	� 5@   
   -   5        $
��Male��5@      $��1��6"   $��2��62   $
��Male��6?    d� 	IsChecked$
 TrueY�6N   	� 5A   
   -   5        $��Female��5A      $��1��6$   $��3��64   $��Female��6A   (  "System.Windows.Controls.DatePicker  5B   
   -   5        $��MyDate��5B      $��1��6#   $��4��63   �� 5C   
   -   5        $��BirthCountry��5C      $��1��6&   $��5��66   �� 5D   
   -   5        $��Salary��5D      $��1��6    $��6��60   .��6=   ��5E      �� 5F       �� Path$
 Self�6    �� UpdateSourceTrigger$ PropertyChanged=�6&    �� ValidationRules 5G         WPFlab2.SalaryValidation  5H      
   Min$
 5000��61   6>   5J      .��5K      5L      �� 5M   
   -   5        $��SalaryCurrency��5M      $��1��6)   $��7��69    �� SelectedIndex$ 0��6�   ��6F   ��  �� Source# [ 6�   �� 5N   
   -	   5        $��CompanyRole��5N      $��1��6&   $��8��66   $ 0��6y   ��6C   �� # [  6y   �� 5O   
   -
   5        $	��Add��5O      $��9��6   $��2��6)   $	��Add��6=   $��2��6K   $��30��6\   6h   5P      5Q      