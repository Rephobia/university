<?xml version="1.0" encoding="utf-8"?>
<CFC version="1.0.0">
  <BlockList>
    <Block type="Input" localId="1" width="80" height="30">
      <Position x="50" y="50"/>
      <Pins>
        <Pin type="Output" name="x1" datatype="BOOL"/>
      </Pins>
    </Block>
    <Block type="Input" localId="2" width="80" height="30">
      <Position x="50" y="110"/>
      <Pins>
        <Pin type="Output" name="x2" datatype="BOOL"/>
      </Pins>
    </Block>
    <Block type="Input" localId="3" width="80" height="30">
      <Position x="50" y="170"/>
      <Pins>
        <Pin type="Output" name="x3" datatype="BOOL"/>
      </Pins>
    </Block>

    <Block type="NOT" localId="4" width="60" height="30">
      <Position x="200" y="50"/>
    </Block>
    <Block type="NOT" localId="5" width="60" height="30">
      <Position x="200" y="110"/>
    </Block>
    <Block type="NOT" localId="6" width="60" height="30">
      <Position x="200" y="170"/>
    </Block>

    <Block type="AND" localId="7" width="80" height="50">
      <Position x="340" y="30"/>
    </Block>
    <Block type="AND" localId="8" width="80" height="50">
      <Position x="340" y="110"/>
    </Block>
    <Block type="AND" localId="9" width="80" height="50">
      <Position x="340" y="190"/>
    </Block>
    <Block type="AND" localId="10" width="80" height="50">
      <Position x="340" y="270"/>
    </Block>

    <Block type="OR" localId="11" width="80" height="80">
      <Position x="500" y="110"/>
    </Block>

    <Block type="Output" localId="12" width="80" height="30">
      <Position x="660" y="130"/>
      <Pins>
        <Pin type="Input" name="y" datatype="BOOL"/>
      </Pins>
    </Block>
  </BlockList>

  <ConnectionList>
    <Connection fromBlock="1" fromPin="1" toBlock="4" toPin="1"/>
    <Connection fromBlock="4" fromPin="1" toBlock="7" toPin="1"/>
    <Connection fromBlock="2" fromPin="1" toBlock="7" toPin="2"/>
    <Connection fromBlock="3" fromPin="1" toBlock="7" toPin="3"/>

    <Connection fromBlock="1" fromPin="1" toBlock="8" toPin="1"/>
    <Connection fromBlock="2" fromPin="1" toBlock="5" toPin="1"/>
    <Connection fromBlock="5" fromPin="1" toBlock="8" toPin="2"/>
    <Connection fromBlock="3" fromPin="1" toBlock="6" toPin="1"/>
    <Connection fromBlock="6" fromPin="1" toBlock="8" toPin="3"/>

    <Connection fromBlock="1" fromPin="1" toBlock="9" toPin="1"/>
    <Connection fromBlock="2" fromPin="1" toBlock="9" toPin="2"/>
    <Connection fromBlock="6" fromPin="1" toBlock="9" toPin="3"/>

    <Connection fromBlock="1" fromPin="1" toBlock="10" toPin="1"/>
    <Connection fromBlock="2" fromPin="1" toBlock="10" toPin="2"/>
    <Connection fromBlock="3" fromPin="1" toBlock="10" toPin="3"/>

    <Connection fromBlock="7" fromPin="1" toBlock="11" toPin="1"/>
    <Connection fromBlock="8" fromPin="1" toBlock="11" toPin="2"/>
    <Connection fromBlock="9" fromPin="1" toBlock="11" toPin="3"/>
    <Connection fromBlock="10" fromPin="1" toBlock="11" toPin="4"/>

    <Connection fromBlock="11" fromPin="1" toBlock="12" toPin="1"/>
  </ConnectionList>
</CFC>