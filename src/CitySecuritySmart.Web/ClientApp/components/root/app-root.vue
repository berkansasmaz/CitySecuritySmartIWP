<template>

  <!-- / Layout navbar -->

  <div class="layout-container" id="app">

    <nav-menu params="route: route"></nav-menu>

    <div class="layout-content">
      <!-- Page content -->
      <div class="container-fluid flex-grow-1 container-p-y">
        <notifications />

        <div v-if="url == '/' " class="portfolio-image ui-rect ui-rect-30 ui-bg-cover"
          style="background-image: url('assets/img/avatars/Smart.jpg');"></div>

        <!-- Content -->
        <div v-if="url == '/' " class="bg-white">
          <div class="container px-3">
            <div class="col-lg-10 col-xl-8 py-5 px-0 mx-auto">

              <!-- Article caption -->
              <div class="pb-5">
                <h1 class="font-weight-bold text-center">
                  CITY SECURITY SMART
                </h1>
                <!-- Tags -->
              </div>
              <!-- / Article caption -->

              <p class="mb-4">
                City Security Smart (CSS): Güvenlik sistemlerinde görüntü ve ses içeriğinin otomatik olarak analiz
                edilmesi önemli bir ihtiyaçtır. CSS projesinin temel amacı, kavram tanıma konusundaki bilgi birikimi ve
                geliştirilen altyapıyı güvenlik sistemlerine uyarlamaktır.
              </p>
              <p class="mb-4">
                Kavram tanıma, görsel ve işitsel kavramların bilgisayarlar tarafından öğrenilebilir hale getirilmesi ve
                otomatik tespiti olarak tanımlanabilir.

                İlk aşamada, örnek veriler üzerinden kavram modelleri öğrenilir. Tespit aşamasında, test verisinin bu
                modellere uygunluğu incelenerek aranan kavramın varlığı ya da yokluğuna karar verilir. Bir kez öğrenilen
                modeller tüm testlerde kullanılabileceği gibi güncellenerek yeni durumlara uyarlanabilirler. Ayrıca,
                sistemin hassasiyet derecesi ayarlanabilir; bu sayede yanlış uyarılar ile kaçırma riski arasındaki denge
                noktası ihtiyaca göre değiştirilebilir.

                AGS Projesinde, KAVTAN Projesi kapsamında elde edilen bilgi birikimi ve yazılım altyapısı, güvenlikle
                ilgili kavramlara uyarlanmış ve prototip bir sistem geliştirilmiştir.
              </p>
              <p class="mb-2">
                Prototip sistem üç temel işlevi yerine getirmektedir:
                <ul>
                  <li>
                    Canlı görüntü izleme
                  </li>
                  <li>
                    Kavram tanıma analizi
                  </li>
                  <li>
                    Arşivleme
                  </li>
                </ul>
              </p>
              <p class="mb-2">
                Kavram Listesi:
                <ul>
                  <li>Yangın</li>
                  <li>Patlama Sesi</li>
                  <li>Kalabalık</li>
                  <li>İnsan Varlığı</li>
                  <li>Kavga</li>
                  <li>Trafik Kazası</li>
                  <li>Şüpheli Nesne</li>
                  <li>Alevli Nesne</li>
                </ul>
              </p>
              <p class="my-1">
                <img src="assets/img/avatars/Gelecekte.png" alt class="img-fluid">
              </p>
              <div class="fusion-reading-box-container reading-box-container-1"
                style="margin-top:10px;margin-bottom:30px;">
                <div class="reading-box"
                  style="background-color:#f6f6f6; border-width:1px; border-color:#f6f6f6;border-left-width:3px; border-left-color:#7FFFD4; border-style:solid;">
                  <div class="reading-box-additional">
                    <p style="text-align: center;">Şehirlerin küresel olarak birbirine bağlı bir ekonomide rekabet etme
                      ve kent sakinlerinin refahını sürdürülebilir bir şekilde sağlayabilme ihtiyacı ülkeleri ve
                      şehirleri yeni teknoloji ve yenilikçi yaklaşımları değerlendirmeye yönlendirmektedir. Bu
                      motivasyon, söz konusu teknoloji ve yaklaşımların getirdiği karmaşıklık ve değişim hızı,
                      geleneksel silo çözümleri geliştiren ekosistem paydaşlarını zorlamakta, şehir çözümlerinin
                      bütüncül ve sistematik olarak ele alınması ihtiyacını ortaya çıkarmaktadır. Bu ihtiyacın
                      karşılanmasında, paydaşlar arası iş birliği ile geliştirilen birlikte çalışabilir sistemlerin veri
                      ve uzmanlığa dayalı olarak gelecek öngörüleriyle beklenti ve problemleri karşıladığını güvence
                      altına alan Akıllı Şehir yaklaşımı çözüm olmaktadır.</p>
                  </div>
                  <div class="fusion-clearfix"></div>
                </div>
              </div>
            </div>
          </div>
        </div>

        <router-view ></router-view>
      </div>
      <!-- / Page content -->
    </div>
  </div>
</template>

<script>
  import NavMenu from "./nav-menu";
  import router from "@/router";

  export default {
    components: {
      "nav-menu": NavMenu
    },
    data() {
      return {
		  	url: `${this.$route.path}`,
	  };
	},
	methods: {
		urlChanged(){
			this.url =  `${this.$route.path}`;
		}
	},
	watch: {
		'$route': 'urlChanged'
	},
	created() {
		this.urlChanged()
	},
  };

</script>

<style>
</style>
