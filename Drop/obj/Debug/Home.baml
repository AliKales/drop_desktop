   M S B A M L   `   `   `  ?????  ;Drop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DropDrop  5          	Drop.Home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Drop     5        N? Title$
  Home??5	      .??5      ?? -   5        $??
ImagePanel??5      ???#272537 ?? CornerRadius$ 15??5       J? 	AllowDrop . ._?5   
   ? $??5,0,5,5q?6    ? RowDefinitions 5      ?? 5      $??30 ?6    ?? 5      $??40 ?6    ?? 5      ?? 5      $??40 ?6    ?? 5      .+?5      ?  ? ColumnDefinitions 5      ?? 5      ?? 5      $??25 ?6'   ?? 5      $??25 ?6'   ?? 5      $??5 ?6'   .+?5"      ?? -   5        $??15??5"      $??15??5#      $
??Left=?5%      $??5,0,0,0q?5&      ??5(      ?? 5)      .R?5*      ? .+?5+   "   A? 
??? ? ?6*   ?? 5,   "   $??Center=?63   $??Center=?6P   5-      5.      51      ?? 53      -   5        $??1??53      $??15??54      $??15??55      ??58      ?? 59      .R?5:      ? .+?5;   "   A? ???#ffbd2e6*   ?? 5<   "   $??Center=?63   $??Center=?6P   5=      5>      5A      ?? 5C      -   5        $??2??5C      $??15??5D      $??15??5E      ??5H      ?? 5I      .R?5J      ? .+?5K   "   A? ???#ff5f566*   ?? 5L   "   $??Center=?63   $??Center=?6P   5M      5N      5Q      5T      ?? 5V      $??SEND A TEXT??6   $??1??5W      
???????$??22(?5Y      $??Medium"?5Z      $??Center=?5[      $??Center=?5\      ?? 5^      $??2??6    ?? Orientation$ 
Horizontal=?5_      .+?5`      ?? -   5         ??Name$ txtText??5`       ?? AcceptsReturn .  ?? TextWrapping$
 Wrap=?5b      $??16(?5d      $	??800??5e      $??Medium"?5f      
?????? 
???????	 ?? 
CaretBrush
	 ?????
???????$??0,0,0,1q?5k      ?? 5m      -   5        
 ??Name$
 btnLogin??5m      $??0q?5n      $??OK??5o      
???????$??12(?5q      $??10,0,0,0q?5s       ? Cursor$
 Hand??5t      ??5v      ?? 5w       ?? 
TargetType" ??6    .?5x      ??  ?? Property ? ?? ?? Value
 ?? ??6;    ?? Triggers 5y      P? 5z   "    P? Property ?@J?IsMouseOver P? Value . . ?5{   &   ??  ? ??
 ?? ??6C   5|   #   5~      ??5?      ?? 5?       ?? 
TargetType" ??6*   .R?5?      ?? $??80??6%   $??40??60   $ 9??5?   %   #??z??5?   %   ._?5?   "   ?? $??Center=?63   $??Center=?5?   3   5?      5?      5?      5?      ?? 5?      $??SEND A FILE??6   $??3??5?      
???????$??22(?5?      $??Medium"?5?      $??Center=?5?      $??Center=?5?      ?? 5?      -   5         ??Name$ drag1??5?      $??4??5?      $ 
Horizontal=?5?      $??Center=?5?      $??Center=?5?      .+?5?      ?? $??Drag a File Right Here??6   
???????$??30(?5?      $??Center=?5?       ?? Padding$ 0,0,5,0q?5?      $??Medium"?5?      ?? 5?      $ 8,8,8,8??6   $	??100??5?      $	??100??5?      ??5?      ?? 5?       ?? ImageSource$ \Resources\file.png??6&   5?      5?      ?? 5?      -   5        $ drag2??5?      $??4??5?      $ Vertical=?5?      $??Center=?5?      $y?Hidden=?5?      $??Center=?5?      .+?5?      ?? -	   5        $??2??5?      $??15??5?      $??15??5?      $??Right=?5?      ??5?      ?? 5?      .R?5?      ? .+?5?   "   A? ???#ff5f566*   ?? 5?   "   $??Center=?63   $??Center=?6P   5?      5?      5?      ?? 5?      -
   5         ??Name$ txtFile??5?      
???????$??17(?5?      $??Medium"?5?      $??Deneme??5?      ?? 5?      -   5        $??0q?5?      $
??SEND??5?      
???????$??12(?5?      $
 Hand??5?      $??0,30,0,0q?5?      ??5?      ?? 5?      " ??6    .?5?      ??  ? ??
 ?? ??6;    5?      P? 5?   "    ?@J?IsMouseOver . . ?5?   &   ??  ? ??
 ?? ??6C   5?   #   5?      ??5?      ?? 5?      " ??6*   .R?5?      ?? $	??150??6%   $??40??61   $ 9??5?   %   #??z??5?   %   ._?5?   "   ?? $??Center=?63   $??Center=?5?   3   5?      5?      5?      5?      5?      5?      5?      