   M S B A M L   `   `   `  ????K  GBudgetPlannerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:BudgetPlannerWPFBudgetPlannerWPF  5          BudgetPlannerWPF.RentPage   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:BudgetPlannerWPF     5        N? Title$  RentPage??5	      .??5      ? 
??????? ? ColumnDefinitions 5   
   ?? 5      $??2* ?6   6,   ?? 5      $??3* ?6   6,    ? RowDefinitions 5   
   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   .+?5   
   ?? $??0??6   $??0??6   $??16(?6-   $??Right=?6;   $??Center=?6W   $??0,0,10,0q?6r   .??6?   Monthly Rent:6?   ?? 5   
   -   5         ??Name$ txbRent??5      $??0??6#   $??1??60   $??24??6@   $
??auto??6L    ?? TextWrapping$
 Wrap=?6Y   
???   ?$??16(?6?   $??0,0,50,0q?6?   ?? 5   
   -   5         ??Name$ lblRentError??5      $??0??6&   $??1??63   $??12(?6C   $
??Left=?6Q   $??Bottom=?6l   
???  ??$
??auto??6?   $??26??6?   6?   ?? 5   
   -   5         ??Name$ btnRentSubmit??5      $??1??6(   $??1??68   $	??100??6E   $??38??6Q   $
??Left=?6]   $??Submit??6x   
???????6?   5      5      