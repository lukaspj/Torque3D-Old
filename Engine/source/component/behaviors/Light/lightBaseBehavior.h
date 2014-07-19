//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
#ifndef _LIGHTBASE_BEHAVIOR_H_
#define _LIGHTBASE_BEHAVIOR_H_

#ifndef _BEHAVIORTEMPLATE_H_
	#include "component/behaviors/behaviorTemplate.h"
#endif
#ifndef _LIGHTINFO_H_
#include "lighting/lightInfo.h"
#endif
#ifndef _LIGHTFLAREDATA_H_
#include "T3D/lightFlareData.h"
#endif
#ifndef _LIGHTANIMDATA_H_
#include "T3D/lightAnimData.h"
#endif

//////////////////////////////////////////////////////////////////////////
/// 
/// 
//////////////////////////////////////////////////////////////////////////
class LightBaseBehavior : public BehaviorTemplate
{
   typedef BehaviorTemplate Parent;

public:
   LightBaseBehavior();
   virtual ~LightBaseBehavior();
   DECLARE_CONOBJECT(LightBaseBehavior);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual U32 packUpdate(NetConnection *con, U32 mask, BitStream *stream);
   virtual void unpackUpdate(NetConnection *con, BitStream *stream);

   //override to pass back a LightBaseBehaviorInstance
   virtual BehaviorInstance *createInstance();
};

class LightBaseBehaviorInstance : public BehaviorInstance, public ISceneLight
{
   typedef BehaviorInstance Parent;
   friend class LightAnimData;
   friend class LightFlareData;

protected:

   bool mIsEnabled;

   ColorF mColor;

   F32 mBrightness;

   bool mCastShadows;

   F32 mPriority;

   LightInfo *mLight;

   LightAnimData *mAnimationData; 
   LightAnimState mAnimState;

   LightFlareData *mFlareData;
   LightFlareState mFlareState;   
   F32 mFlareScale;

   static bool smRenderViz;

   virtual void _conformLights() {}

   void _onRenderViz(   ObjectRenderInst *ri, 
                        SceneRenderState *state, 
                        BaseMatInstance *overrideMat );

   virtual void _renderViz( SceneRenderState *state ) {}

   enum LightMasks
   {
      InitialUpdateMask = Parent::NextFreeMask,
      EnabledMask       = Parent::NextFreeMask << 1,
      TransformMask     = Parent::NextFreeMask << 2,
      UpdateMask        = Parent::NextFreeMask << 3,
      DatablockMask     = Parent::NextFreeMask << 4,      
      NextFreeMask      = Parent::NextFreeMask << 5
   };

   // SimObject.
   virtual void _onSelected();
   virtual void _onUnselected();

public:
   LightBaseBehaviorInstance(BehaviorTemplate *btemplate = NULL);
   virtual ~LightBaseBehaviorInstance();
   DECLARE_CONOBJECT(LightBaseBehaviorInstance);

   virtual bool onAdd();
   virtual void onRemove();
   static void initPersistFields();

   virtual void onBehaviorAdd();
   virtual void onBehaviorRemove();

   virtual U32 packUpdate( NetConnection *conn, U32 mask, BitStream *stream );
   virtual void unpackUpdate( NetConnection *conn, BitStream *stream );

   virtual void prepRenderImage( SceneRenderState *state );

   // ISceneLight
   virtual void submitLights( LightManager *lm, bool staticLighting );
   virtual LightInfo* getLight() { return mLight; }

   /// Toggles the light on and off.
   void setLightEnabled( bool enabled );
   bool getLightEnabled() { return mIsEnabled; };

   /// Animate the light.
   virtual void pauseAnimation( void );
   virtual void playAnimation( void );
   virtual void playAnimation( LightAnimData *animData );
};

#endif // _LIGHTBASE_BEHAVIOR_H_
