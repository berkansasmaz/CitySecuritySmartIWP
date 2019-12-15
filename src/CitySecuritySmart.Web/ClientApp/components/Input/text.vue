<template>
  <div>
    <div class="card mb-4">
      <h6 class="card-header text-center">
     			 <div class>Video Url:  https://storage.cloud.google.com/mts-bucket/{{value}}
				 <button class="btn btn-xs btn-info" v-on:click="(hiden = true && userLink())" v-if="value">Preview</button>
		</div>
      </h6>
      <div class="card-body">
        <input 
			type="text"
		 	:placeholder="placeholder"
			class="form-control"
			v-bind:value="value"
			v-on:input="$emit('input', $event.target.value)"
		    >	
		</div>
    </div>
<template v-if="hiden">
	<div class="card mb-4">
   		 <div class="embed-responsive embed-responsive-16by9">
  			<iframe class="embed-responsive-item" :src=url allowfullscreen></iframe>
		</div>
  </div>
</template>
	
  </div>
</template>

<script>
export default {
	data() {
		return {
			hiden: false,
			url: ""
		}
	},
	methods: {
	  userLink() {
		  this.url = `https://storage.cloud.google.com/mts-bucket/${this.value}`;
		  return this.url;
	  }
  },
	props: {
		value: {
			default: null,
			type: String
		},
		placeholder: {
			type: String,
			default : ""
		}
	}
}
</script>