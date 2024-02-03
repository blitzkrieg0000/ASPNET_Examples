# Tag Helpers
## "A" Tag Helper
```
	"onPressActivate" attribute'una sahip her "<a>" html etiketi için "href" değerini md5 ile hashleyip "data-hash" attribute değerine yazar. Bu değer her bir "<a>" etiketinin tanımlayıcı değişmez değeri olur. Burada bu yöntemi, üzerine basılan tuşun bir sonraki sayfa yenilenmesinde hangi tuş olduğu bilgisine ulaşmak için geliştirdim. MD5 hash'inden yola çıkarak bu değer cookiede tutulup, bir sonraki sayfa yenilenmesinde "_AdminLayout.cshtml" de JavaScript'in "onload document" fonksiyonu ile her sayfa yenilenmesinde cookielerden okunup işleme tabi tutuluyor.
```
## "TimeLog, Bold, Condition" Tag Helpers
```
	Örnek amacıyla koyulmuş tag helperlardır.
```