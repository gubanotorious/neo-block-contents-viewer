# neo-block-contents-viewer
Command line application to retrieve a block via NEO RPC and output as JSON or Hex

### Usage: 
`dotnet NEOBlockContentsViewer.dll [arguments] [options]`

### Arguments:
- block     - The block height to retrieve
- endpoint  - The rpc endpoint to use (defaults to http://localhost:10332 if omitted)

### Options:
- -?|-h|--help  - Show help information
- --raw         - Retrieve the raw bytes

### Examples:
#### Retrieve block 5000 as JSON, using the default local mainnet configuration (http://localhost:10332):

###### Command Line: 
`dotnet NEOBlockContentsViewer.dll 5000`

###### Output:
``` javascript 
Retrieve block at 5000
{
  "hash": "0xc0ceaa2637df7592cb9e7702d92bdec00d3dde51e5cb145ef8cb713fa20ea95b",
  "size": 686,
  "version": 0,
  "previousblockhash": "0x9d12cee2494ff79fc3351755f5a70dff47afbf6f956400443d47b4f0e6d7ca3d",
  "merkleroot": "0x12dd3ddd69b8d36f70ac16a0cc64c38ce9fa01ae8543f9f97e9d27f6db0b8e44",
  "time": 1476740782,
  "index": 5000,
  "nonce": "bd0dbf6550cf0e5f",
  "nextconsensus": "APyEx5f4Zm4oCHwFWiSTaph1fPBxZacYVR",
  "script": {
    "invocation": "40b2f197915f633d20b51d5e2aa31dec9e4275c4df850aa38929b3d8a5d9baf92d613e09a5f223e975c4f0c32e9466ce3dbd807eb3eeba26f75f794a76d8e8874c40d1bcb7cf880537072aad2ac3d9c2b234b2fb6d252e8d60ce30a22c5c4fe55394f9d2877f4be1eca0b60114c162a021cb729bc22abbe51e891f97537024ebd1d24099721ab2e2b446ceee6b0154a87244bdc0f1e185e7b1f670d6f8eafa04cf1cff88abb71db23beb49974f147fe3b6da2af9bb3472f01e7c34d431160d475618a340e1bd9f999c9046a52db78022e6c6295b0fbd21f4be1993a448f87babb17307c361377793423c0bb2e3a568e5bcf64ac1680a2e8be580c1c7d38b830a3f4e953f407990b1860c29cbcc4df29d8a1a386a59e2f0dcc8e4d2492a6f20f3eb7551752a503066eca0c720a797aff13084542187d694e1665adcdeb2feb17c55a5fc1cb8",
    "verification": "552102486fd15702c4490a26703112a5cc1d0923fd697a33406bd5a1c00e0013b09a7021024c7b7fb6c310fccf1ba33b082519d82964ea93868d676662d4a59ad548df0e7d2102aaec38470f6aad0042c6e877cfd8087d2676b0f516fddd362801b9bd3936399e2103b209fd4f53a7170ea4444e0cb0a6bb6a53c2bd016926989cf85f9b0fba17a70c2103b8d9d5771d8f513aa0869b9cc8d50986403b78c6da36890638c3d46a5adce04a2102ca0e27697b9c248f6f16e085fd0061e26f44da85b58ee835c110caa5ec3ba5542102df48f60e8f3e01c48ff40b9b7f1310d7a8b2a193188befe1c2e3df740e89509357ae"
  },
  "tx": [
    {
      "txid": "0x12dd3ddd69b8d36f70ac16a0cc64c38ce9fa01ae8543f9f97e9d27f6db0b8e44",
      "size": 10,
      "type": "MinerTransaction",
      "version": 0,
      "attributes": [],
      "vin": [],
      "vout": [],
      "sys_fee": "0",
      "net_fee": "0",
      "scripts": [],
      "nonce": 1355746911
    }
  ],
  "confirmations": 2554161,
  "nextblockhash": "0xb7a1325be6683d2550cb0fb4427af4c174cbfa7a4c2410752ae7ea086aa41831"
}
```

#### Retrieve block 5000 as Hex using a localhost testnet configuration:

###### Command Line: 
`dotnet NEOBlockContentsViewer.dll 5000 http://localhost:20332 --raw`

###### Output:
```
30303030303030303364636164376536663062343437336434343030363439353666626661663437666630646137663535353137333563333966663734663439653263653132396434343865306264626636323739643765663966393433383561653031666165393863633336346363613031366163373036666433623836396464336464643132616534363035353838383133303030303566306563663530363562663064626435396537356436353262356433383237626630346331363562626539656639356363613462663535303166643435303134306232663139373931356636333364323062353164356532616133316465633965343237356334646638353061613338393239623364386135643962616639326436313365303961356632323365393735633466306333326539343636636533646264383037656233656562613236663735663739346137366438653838373463343064316263623763663838303533373037326161643261633364396332623233346232666236643235326538643630636533306132326335633466653535333934663964323837376634626531656361306236303131346331363261303231636237323962633232616262653531653839316639373533373032346562643164323430393937323161623265326234343663656565366230313534613837323434626463306631653138356537623166363730643666386561666130346366316366663838616262373164623233626562343939373466313437666533623664613261663962623334373266303165376333346434333131363064343735363138613334306531626439663939396339303436613532646237383032326536633632393562306662643231663462653139393361343438663837626162623137333037633336313337373739333432336330626232653361353638653562636636346163313638306132653862653538306331633764333862383330613366346539353366343037393930623138363063323963626363346466323964386131613338366135396532663064636338653464323439326136663230663365623735353137353261353033303636656361306337323061373937616666313330383435343231383764363934653136363561646364656232666562313763353561356663316362386631353532313032343836666431353730326334343930613236373033313132613563633164303932336664363937613333343036626435613163303065303031336230396137303231303234633762376662366333313066636366316261333362303832353139643832393634656139333836386436373636363264346135396164353438646630653764323130326161656333383437306636616164303034326336653837376366643830383764323637366230663531366664646433363238303162396264333933363339396532313033623230396664346635336137313730656134343434653063623061366262366135336332626430313639323639383963663835663962306662613137613730633231303362386439643537373164386635313361613038363962396363386435303938363430336237386336646133363839303633386333643436613561646365303461323130326361306532373639376239633234386636663136653038356664303036316532366634346461383562353865653833356331313063616135656333626135353432313032646634386636306538663365303163343866663430623962376631333130643761386232613139333138386265666531633265336466373430653839353039333537616530313030303035663065636635303030303030303030
```



