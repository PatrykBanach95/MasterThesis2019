   M S B A M L   `   `   `  ����G  CMasterThesis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PracaMagisterskaPracaMagisterska  5   	   (    "PracaMagisterska.InstructionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PracaMagisterska     5   	   -   5          � Title$  Instruction��5   	   $	��700��6   $
��1200��6*    � WindowStartupLocation$ Manual=�67    � WindowState$ 	Maximized=�6V   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ 	#FF94CDE2��6   5      .+�5   
   �� -   5         ��Name$ Return��5      $��Zamknij��6!   $
��Left=�63   $	��Top=�6N   $	��259��6f   $��38��6�   $��
37,186,0,0q�6�   ���	#FF55A4AC
����������	#FF6AB5C1$��16(�6�   �� 5   
   -   5        $ 	btn_Voice��5      $��Sterowanie głosem��6$   $
��Left=�6@   $	��Top=�6[   $	��259��6s   $��38��6�   $��	37,34,0,0q�6�   ���	#FF55A4AC
����������	#FF6AB5C1$��16(�6�   �� 5   
   -   5        $ btn_VoicePlusGesture��5      $"��Sterowanie głosem + gestami��6/   $
��Left=�6U   $	��Top=�6p   $	��259��6�   $��38��6�   $��	37,72,0,0q�6�   ���	#FF55A4AC
����������	#FF6AB5C1$��16(�6  �� 5   
   -   5        $ btn_Gesture��5      $��Sterowanie gestami��6&   $
��Left=�6C   $	��Top=�6^   $	��259��6v   $��38��6�   $��
37,110,0,0q�6�   ���	#FF55A4AC
����������	#FF6AB5C1$��16(�6�   �� 5   
   -   5        $ btn_PickAndPlace��5      $��Program PickAndPlace��6+   $
��Left=�6J   $	��Top=�6e   $	��259��6}   $��38��6�   $��
37,148,0,0q�6�   ���	#FF55A4AC
����������	#FF6AB5C1$��16(�6  �� 5   
   -   5        $��Voice��5      $C��=W celu sterowania głosem zadeklarowane zostało 6 poleceń: ��6   $
��Left=�6b   $��438,192,0,0q�6}   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $��Voice1��5      $<��6   - 'plus x' ruch robota po osi x w kierunku dodatnim��6   $
��Left=�6_   $��438,223,0,0q�6z   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -	   5        $��Voice2��5      $<��6   - 'minus x' ruch robota po osi x w kierunku ujemnym��6   $
��Left=�6_   $��438,254,0,0q�6z   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -
   5        $��Voice3��5      $<��6   - 'plus y' ruch robota po osi y w kierunku dodatnim��6   $
��Left=�6_   $��438,290,0,0q�6z   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $��Voice4��5      $<��6   - 'minus y' ruch robota po osi y w kierunku ujemnym��6   $
��Left=�6_   $��438,321,0,0q�6z   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $��Voice5��5      $<��6   - 'plus z' ruch robota po osi z w kierunku dodatnim��6   $
��Left=�6_   $��438,357,0,0q�6z   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $��Voice6��5      $<��6   - 'minus z' ruch robota po osi z w kierunku ujemnym��6   $
��Left=�6_   $��438,388,0,0q�6z   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $��VoiceAndGesture��5      $w��qDo sterowania poprzez kombinacje poleceń głosowych i gestów zaimplementowane zostału następujące polecenia:��6'   $
��Left=�6�   $��
336,43,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6  �� 5   
   -   5        	 ��Name$	 Voice7��5      $*��$   - 'stop' zatrzymuje pracę robota��6    $
��Left=�6N   $��438,419,0,0q�6i   $	��Top=�6~   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $	 VoiceAndGesture1��5      $0��*   - 'axis x' ustawia oś x jako oś ruchu��6*   $
��Left=�6]   $��
336,74,0,0q�6x   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5   
   -   5        $	 VoiceAndGesture2��5      $0��*   - 'axis y' ustawia oś y jako oś ruchu��6*   $
��Left=�6]   $��336,105,0,0q�6x   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5    
   -   5        $	 VoiceAndGesture3��5       $0��*   - 'axis z' ustawia oś y jako oś ruchu��6*   $
��Left=�6]   $��336,136,0,0q�6x   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5!   
   -   5        $	 VoiceAndGesture4��5!      $V��PAby sterować w danym kierunku należy użyć następujęcego ustawienia ciała:��6*   $
��Left=�6~   $��336,182,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5"   
   -   5        $	 VoiceAndGesture5��5"      $b��\   - ruch w kierunku dodatnim odbywa się poprzez zamknięcie prawej dłoni i ustawienie jej��6*   $
��Left=�6�   $��336,213,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5#   
   -   5        $	 VoiceAndGesture6��5#      $A��;     na prawo względem prawego łokcia ( rysunek numer 1 )��6*   $
��Left=�6n   $��336,232,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5$   
   -   5        $	 VoiceAndGesture7��5$      $a��[   - ruch w kierunku ujemnym odbywa się poprzez zamknięcie prawej dłoni i ustawienie jej��6*   $
��Left=�6�   $��336,266,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5%   
   -   5        $	 VoiceAndGesture8��5%      $@��:     na lewo względem prawego łokcia ( rysunek numer 2 )��6*   $
��Left=�6m   $��336,285,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5&   
   -   5        $	 VoiceAndGesture9��5&      $6��0Rysunek numer 1: ruch robota w kierunku ujemnym:��6*   $
��Left=�6e   $��114,335,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5'   
   -   5        $	 VoiceAndGesture10��5'      $6��0Rysunek numer 1: ruch robota w kierunku ujemnym:��6+   $
��Left=�6f   $��696,335,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5(   
   -   5        $��VoiceAndGesture11��5(      $
��Left=�6)   $	��248��6D   $��184,388,0,0q�6Q   $	��Top=�6f   $	��249��6~   $��Resources/plusAxis.PNG��6�   $y�Hidden=�6�   �� 5)   
   -   5        $��VoiceAndGesture12��5)      $
��Left=�6)   $	��248��6D   $��762,393,0,0q�6Q   $	��Top=�6f   $	��249��6~   $��Resources/minusAxis.PNG��6�   $y�Hidden=�6�   �� 5*   
   -   5        $	 Gesture��5*      $G��ADo sterowania gestami zaimplementowano sześć zestawów gestów:��6!   $
��Left=�6i   $��
382,29,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5+   
   -   5        $	 Gesture1��5+      $b��\   - ruch w dodatnim kierunku osi y odbywa się, kiedy lewa dłoń jest zamknięta, znajduje��6"   $
��Left=�6�   $��
382,60,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5,   
   -   5        $	 Gesture2��5,      $t��n     się poniżej barku, a prawa dłoń znajduje się na prawo względem prawego łokcia  ( rysunek numer 1 )��6"   $
��Left=�6�   $��
382,78,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5-   
   -   5        $	 Gesture3��5-      $a��[   - ruch w ujemnym kierunku osi y odbywa się, kiedy lewa dłoń jest zamknięta, znajduje��6"   $
��Left=�6�   $��382,103,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5.   
   -    5        $	 Gesture4��5.      $s��m     się poniżej barku, a prawa dłoń znajduje się na lewo względem prawego łokcia ( rysunek numer 2  )��6"   $
��Left=�6�   $��382,121,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5/   
   -!   5        $	 Gesture5��5/      $b��\   - ruch w dodatnim kierunku osi x odbywa się, kiedy lewa dłoń jest zamknięta, znajduje��6"   $
��Left=�6�   $��382,147,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 50   
   -"   5        $	 Gesture6��50      $o��i     się pomiędzy barkiem, a czubkiem głowy i  prawa dłoń znajduje się na prawo ( rysunek numer 3 )��6"   $
��Left=�6�   $��382,165,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 51   
   -#   5        $	 Gesture8��51      $a��[   - ruch w ujemnym kierunku osi x odbywa się, kiedy lewa dłoń jest zamknięta, znajduje��6"   $
��Left=�6�   $��382,190,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 52   
   -$   5        $	 Gesture9��52      $n��h     się pomiędzy barkiem, a czubkiem głowy i  prawa dłoń znajduje się na lewo ( rysunek numer 4 )��6"   $
��Left=�6�   $��382,208,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 53   
   -%   5        $	 	Gesture11��53      $b��\   - ruch w dodatnim kierunku osi z odbywa się, kiedy lewa dłoń jest zamknięta, znajduje��6#   $
��Left=�6�   $��382,236,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 54   
   -&   5        $	 	Gesture12��54      $o��i     powyżej głowy,a  prawa dłoń znajduje się na prawo względem prawego łokcia ( rysunek numer 5 )��6#   $
��Left=�6�   $��382,254,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 55   
   -'   5        $	 	Gesture14��55      $c��]   - ruch w dodatnim kierunku osi z odbywa się, kiedy lewa dłoń jest zamknięta, znajduje ��6#   $
��Left=�6�   $��382,281,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 56   
   -(   5        $	 	Gesture15��56      $s��m     się powyżej głowy i  prawa dłoń znajduje się na lewo względem prawego łokcia ( rysunek numer 6 )��6#   $
��Left=�6�   $��382,299,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 57   
   -)   5        $	 	Gesture16��57      $��Rysunek numer 1:��6#   $
��Left=�6>   $��
66,344,0,0q�6Y   $	��Top=�6m   $��16(�6�   
�������$y�Hidden=�6�   �� 58   
   -*   5        $	 	Gesture17��58      $��Rysunek numer 2:��6#   $
��Left=�6>   $��438,344,0,0q�6Y   $	��Top=�6n   $��16(�6�   
�������$y�Hidden=�6�   �� 59   
   -+   5        $	 	Gesture18��59      $��Rysunek numer 3:��6#   $
��Left=�6>   $��807,344,0,0q�6Y   $	��Top=�6n   $��16(�6�   
�������$y�Hidden=�6�   �� 5:   
   -,   5        $	 	Gesture19��5:      $��Rysunek numer 4:��6#   $
��Left=�6>   $��
66,491,0,0q�6Y   $	��Top=�6m   $��16(�6�   
�������$y�Hidden=�6�   �� 5;   
   --   5        $	 	Gesture21��5;      $��Rysunek numer 5:��6#   $
��Left=�6>   $��438,491,0,0q�6Y   $	��Top=�6n   $��16(�6�   
�������$y�Hidden=�6�   �� 5<   
   -.   5        $	 	Gesture22��5<      $��Rysunek numer 6:��6#   $
��Left=�6>   $��807,491,0,0q�6Y   $	��Top=�6n   $��16(�6�   
�������$y�Hidden=�6�   �� 5=   
   -/   5        $��	Gesture23��5=      $
��Left=�6!   $	��133��6<   $��245,357,0,0q�6I   $	��Top=�6^   $	��138��6v   $��Resources/plusY.PNG��6�   $y�Hidden=�6�   �� 5>   
   -0   5        $��	Gesture24��5>      $
��Left=�6!   $	��133��6<   $��245,508,0,0q�6I   $	��Top=�6^   $	��138��6v   $��Resources/minusX.PNG��6�   $y�Hidden=�6�   �� 5?   
   -1   5        $��	Gesture25��5?      $
��Left=�6!   $	��133��6<   $��598,357,0,0q�6I   $	��Top=�6^   $	��138��6v   $��Resources/minusY.PNG��6�   $y�Hidden=�6�   �� 5@   
   -2   5        $��	Gesture26��5@      $
��Left=�6!   $	��133��6<   $��598,508,0,0q�6I   $	��Top=�6^   $	��138��6v   $��Resources/plusZ.PNG��6�   $y�Hidden=�6�   �� 5A   
   -3   5        $��	Gesture27��5A      $
��Left=�6!   $	��133��6<   $��966,357,0,0q�6I   $	��Top=�6^   $	��138��6v   $��Resources/plusX.PNG��6�   $y�Hidden=�6�   �� 5B   
   -4   5        $��	Gesture28��5B      $
��Left=�6!   $	��133��6<   $��966,508,0,0q�6I   $	��Top=�6^   $	��138��6v   $��Resources/minusZ.PNG��6�   $y�Hidden=�6�   �� 5C   
   -5   5        $��PickAnPlace��5C      $a��[Ten tryb działa na polecenie 'pick and play' i wykonuje gotowy program. Imituje pobieranie��6#   $
��Left=�6�   $��
438,78,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5D   
   -6   5        $��PickAnPlace1��5D      $^��Xprzedmiotów z przenośnika i odkładanie ich do skrzynki mieszczącej dziewięć sztuk.��6$   $
��Left=�6�   $��
438,99,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5E   
   -7   5        $��PickAnPlace2��5E      $_��YPoniższy rysunek przedstawia schemat blokowy stacji, a numerki znajdujące się na bloku��6$   $
��Left=�6�   $��438,121,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5F   
   -8   5        $��PickAnPlace3��5F      $G��Areprezentującym skrzynkę odpowiadają kolejności odkładania .��6$   $
��Left=�6k   $��438,145,0,0q�6�   $	��Top=�6�   $��16(�6�   
�������$y�Hidden=�6�   �� 5G   
   -9   5        $��PickAnPlace4��5G      $
��Left=�6$   $	��190��6?   $��568,221,0,0q�6L   $	��Top=�6a   $	��189��6y   $��Resources/przenosnik.png��6�   $y�Hidden=�6�   �� 5H   
   -:   5        $��PickAnPlace5��5H      $
��Left=�6$   $	��122��6?   $��736,336,0,0q�6L   $	��Top=�6a   $	��122��6y   $��Resources/robot.png��6�   $y�Hidden=�6�   �� 5I   
   -;   5        $��PickAnPlace6��5I      $
��Left=�6$   $	��122��6?   $��736,458,0,0q�6L   $	��Top=�6a   $	��122��6y   $��Resources/skrzynka.png��6�   $y�Hidden=�6�   5K      5L      