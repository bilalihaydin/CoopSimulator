# Kümes Hayvanları Simülasyon Çalışması
-Proje kümes hayvanlarının yaşam döngüsünü gerçekleştirmeye yönelik bir simülasyon çalışmasıdır.
-Proje App seviyesinde tavşan örneği ile çalıştırılmıştır.
-İlk olarak 1 erkek ve 1 dişi tavşan bulunması senaryosu ile başlamıştır.
-Belirtilen bir yaşam döngüsü(Gün) vardır.Yaşam döngüsünün kaç gün çalışacağı bilgisi appsetting dosyasından alınmaktadır.
-Kümes hayvanları için yaşam döngünsünde sırası ile çiftleşme, doğum ve ölüm olayları bulunmaktadır bu olayların sonucunda zaman bir gün ileri gitmektedir.

# Çiftleşme Olayı
-Dişi tavşanlar için sırasıyla çiftleşme şartlarını taşıyıp taşımadığına bakılır. Şartları karşılayan her dişi tavşan için erkek tavşanlar kendi içerisinde random olarak bir sıraya sokulur.
-Bu sıralamada en yüksek değerli ve çiftleşme şartlarını taşıyan erkek tavşan ile dişi tavşan çiftleştirilir.
      || Çiftleşme Şartları
          Erkek Tavşanlar için;
          1- Ergenliğe erişmiş olması (80 gün)
          Dişi Tavşanlar için;
          1- Ergenliğe erişmiş olması (80 gün)
          2- Hamile olmaması
          3- Emzirme döneminde olmaması (hamilelikten sonraki 5 gün)

# Gebe Kalma Durumu
-Çiftleşen dişi tavşanların hamile kalma ihtimalleri hamilelik oranı ile hesaplanır (%76)
-Gebelik süresi (10 gün)

# Doğum
-Gebelik süresinin sonuna gelmiş olan tavşan yaşı ile orantılı olarak yavru vermektedir. Bu oran tavşanın verimli yaşına yakınlığı yada uzaklığı ile doğru orantılı olarak random bulunur.(İdeal Yaş 150 gün).
-Gebelik döneminde her bir yavrunun dişi yada erkek olma olasılığı %50 olarak eşit dağıtılmıştır.

# Ölüm
-Her döngüde tavşanların ölümü gerçekleşebilir.Bu olay ise tavşanın verimli yaşına yakınlığı ile doğru orantılıdır. İdeal yaşına uzak olan tavşan ölüm ihtimali yükselmektedir.(İdeal Yaş 150 gün).

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
İdeal yaşa göre hesaplanan algoritmada aşağıda belirtilen sabit oranlardan yararlanılmıştır.

#
public static double[] possibilities = { 0.36, 0.23, 0.20, 0.15, 0.10, 0.05, 0.01, 0.003 };
#
